using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw5.DTOs.Requests;
using Cw5.Models;
using System.Data.SqlClient;

namespace Cw5.Services
{
    public class OracleStudentDbService : IDbService
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s16703;Integrated Security=True";

        public IEnumerable<Student> GetStudents()
        {
            var list = new List<Student>();

            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from Student";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    list.Add(st);
                }
            }
            return list;
        }
        public Student GetStudent(string indexNumber)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from Student where indexNumber=@index";

                SqlParameter par = new SqlParameter();
                par.Value = indexNumber;
                par.ParameterName = "index";
                com.Parameters.Add(par);

                con.Open();

                var dr = com.ExecuteReader();
                if (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    return st;
                }
            }
            return null;
        }
    }
}