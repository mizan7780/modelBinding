using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace MvcModelBinding.Models
{
    public class MarksClass
    {
        
        public int traineeID { get; set; }
        public int traineeRound { get; set; }
        public int examNumber { get; set; }
        public int evidenceMark { get; set; }
        public int descriptiveMark { get; set; }
        public int mcqMark { get; set; }
        public DateTime examDate { get; set; }

        private DataSet dataEngine(string str)
        {
            SqlConnection cn = new SqlConnection(@"data source=(LocalDB)\v11.0;attachdbfilename=|DataDirectory|\ExamDatabase.mdf;integrated security=True;");
            SqlDataAdapter ad = new SqlDataAdapter(str,cn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
        }
        public void insertMark()
        {
            dataEngine("insert into ExamTable(traineeID,traineeRound,examNumber,evidenceMark,descriptiveMark,mcqMark,examDate) values("+traineeID+","+traineeRound+","+examNumber+","+evidenceMark+","+descriptiveMark+","+mcqMark+",'"+examDate+"')");
        }

        public MarksClass getMark(int tid,int examNum)
        {
            DataSet ds = dataEngine("select * from examTable where traineeID=" + tid + " and examNumber=" + examNum);
            MarksClass mark = new MarksClass();
            if (ds.Tables[0].Rows.Count == 1)
            {
                mark.traineeID = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                mark.traineeRound = Convert.ToInt32(ds.Tables[0].Rows[0][2]);
                mark.examNumber = Convert.ToInt32(ds.Tables[0].Rows[0][3]);
                mark.evidenceMark = Convert.ToInt32(ds.Tables[0].Rows[0][4]);
                mark.descriptiveMark = Convert.ToInt32(ds.Tables[0].Rows[0][5]);
                mark.mcqMark = Convert.ToInt32(ds.Tables[0].Rows[0][6]);
                mark.examDate = Convert.ToDateTime(ds.Tables[0].Rows[0][7]);
            }
            return mark;
        }
    }
}