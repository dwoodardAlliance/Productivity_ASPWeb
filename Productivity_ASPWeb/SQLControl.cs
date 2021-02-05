using System;
using System.Collections.Generic;
using System.Data;
using global::System.Data.SqlClient;
using global::Microsoft.VisualBasic;
using System.Web;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;
using global::System.IO;

namespace Productivity_ASPWeb
{
    public class SQLControl
    {
        private SqlConnection dbconn = new SqlConnection();
        private SqlCommand DBCmd;
        public SqlDataAdapter DBDA;
        public DataTable DBDT;
        public DataSet DBDS;
        public List<SqlParameter> @params = new List<SqlParameter>();
        public int recordcount;
        public string exception;

        public SQLControl()
        {
        }

        public SQLControl(string connectionstring)
        {
            dbconn = new SqlConnection(connectionstring);
        }

        public void ExecuteQuery(string Query)
        {
            if (GlobalVariables.logProd == 1)
            {
                GlobalVariables.strConnection = "ProductivityProdConnectionString";
            }
            else
            {
                GlobalVariables.strConnection = "ProductivityTestConnectionString";
            }

            dbconn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[GlobalVariables.strConnection].ConnectionString;
            recordcount = 0;
            exception = "";
            try
            {
                dbconn.Open();
                DBCmd = new SqlCommand(Query, dbconn);
                @params.ForEach(p => DBCmd.Parameters.Add(p));
                @params.Clear();
                DBDT = new DataTable();
                DBDS = new DataSet();
                DBDA = new SqlDataAdapter(DBCmd);
                recordcount = DBDA.Fill(DBDS);
            }
            catch (Exception ex)
            {
                exception = "ExecQuery Error: " + ex.Message;
            }
            finally
            {
                if (dbconn.State == ConnectionState.Open)
                {
                    dbconn.Close();
                }
            }
        }

        public void AddParam(string name, object value)
        {
            var NewParam = new SqlParameter(name, value);
            @params.Add(NewParam);
        }

        public bool HasException(bool Report = false)
        {
            if (string.IsNullOrEmpty(exception))
                return false;
            if (Report == true)
 catch (Exception ex)
                {
                    DeleteExcelFile(FileUploadEvents.FileName);
                    ScriptManager.RegisterStartupScript(Page, GetType(), "script1", "alert('error occured:" + ex.Message.ToString() + "');", true)
                    return;
                }
            ClientScriptManager.RegisterOnSubmitStatement(Me.GetType(), "ConfirmSubmit", exception)
                ScriptManager.RegisterStartupScript(This, this.GetType(), Guid.NewGuid().ToString("N"), "alert(exception);", true)
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "alert(exception);", true)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "alert(exception);")
            //Interaction.MsgBox(exception, MsgBoxStyle.Critical, "Exception:");
            //Response.Write(@"<script language='javascript'>alert(exception)</script>");
            return true;
        }
    }
}