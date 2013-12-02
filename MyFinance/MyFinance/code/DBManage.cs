using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace MyFinance
{
    /// <summary>
    /// DBManage 的摘要说明
    /// </summary>
    [Serializable()]
    public static class DBManage
    {

        public static string DSNString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

        /// <summary>
        /// 执行SQL查询语句
        /// </summary>
        /// <param name="DSNString"></param>
        /// <param name="SQL"></param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteQueryDst(string SQL)
        {
            SqlConnection cnn = new SqlConnection(DSNString);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.CommandTimeout = 200;
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataSet dst = new DataSet();

            dat.Fill(dst);
            cnn.Close();
            cnn = null;
            return dst;
        }

        /// <summary>
        /// 执行SQL查询语句
        /// </summary>
        /// <param name="DSNString"></param>
        /// <param name="SQL"></param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteQuery(string SQL)
        {
            return ExecuteQueryDst(SQL).Tables[0];
        }

        /// <summary>
        /// 执行Insert语句，并返回插入记录的标识值
        /// </summary>
        /// <param name="DSNString"></param>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static int ExecuteAppend(string SQL)
        {
            int result = -1;
            try
            {
                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("Set NoCount On");
                sbSQL.AppendLine(SQL);
                sbSQL.AppendLine("Select SCOPE_IDENTITY()");
                sbSQL.AppendLine("Set NoCount Off");

                SqlConnection cn = new SqlConnection(DSNString);
                cn.Open();
                SqlCommand cm = new SqlCommand(sbSQL.ToString(), cn);
                cm.CommandType = CommandType.Text;
                result = int.Parse(cm.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 执行的更新语句
        /// </summary>
        /// <param name="DSNString"></param>
        /// <param name="SQL"></param>
        /// <param name="spFlag">是否需要验证影响行数</param>
        /// <returns></returns>
        public static Boolean ExecuteUpdate(string SQL, bool spFlag)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(DSNString);
                cnn.Open();
                SqlCommand cmm = new SqlCommand(SQL, cnn);
                cmm.CommandType = CommandType.Text;

                int row = cmm.ExecuteNonQuery();

                cnn.Close();

                if (!spFlag)
                {
                    if (row > 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return true;
                }
            }
            catch( Exception ex )
            {
                return false;
            }
        }

        /// <summary>
        /// 含事务执行更新语句
        /// </summary>
        /// <param name="DSNString"></param>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static bool ExecTranscation(params string[] SQL)
        {
            
            using (SqlConnection cnn = new SqlConnection(DSNString))
            {
                cnn.Open();
                SqlCommand comd = cnn.CreateCommand();
                SqlTransaction transation;
                transation = cnn.BeginTransaction("tran");
                comd.Connection = cnn;
                comd.Transaction = transation;
                try
                {
                    foreach (string strSQL in SQL)
                    {
                        comd.CommandText = strSQL;
                        comd.ExecuteNonQuery();
                    }

                    transation.Commit();
                    cnn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    try
                    {
                        transation.Rollback();
                        return false;
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine("Rollback Exceptiop Type:{0}", ex2.GetType());
                        return false;
                    }
                }
            }
        }

        public static string FormatSQLText(string sql)
        {
            return sql.Replace("'", "''");
        }

        public static void ExecuteNonQuery(string sql)
        {
            SqlConnection scon = new SqlConnection(DSNString);
            scon.Open();
            SqlCommand scmd = new SqlCommand(sql, scon);                
            scmd.ExecuteNonQuery();
            scon.Close();
        }
    }
}