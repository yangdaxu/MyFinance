using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace MyFinance
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //    SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
        //    sb.DataSource = "yangdaxu";
        //    sb.InitialCatalog = "test";
        //    sb.Password = "123";
        //    sb.UserID = "sa";
        //    SqlConnection scon = new SqlConnection(sb.ConnectionString);
        //    string strsql = "create table aaaaaaaa(a int)";            
        //    SqlCommand sc = new SqlCommand(strsql, scon);
        //    scon.Open();
        //    int a=sc.ExecuteNonQuery();
            
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string str = txt.Text;
            DBManage.ExecuteNonQuery(str);
            //if (DBManage.ExecuteUpdate(str, false))
            //{
            //    this.lblMessage.Text = "<script type=\"text/javascript\"> alert('执行成功');</script>";
            //}
            //else
            //{
            //    this.lblMessage.Text = "<script type=\"text/javascript\"> alert('执行失败');</script>";
            //}
        }
    }
}