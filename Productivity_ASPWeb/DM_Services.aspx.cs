using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using global::System.Data.SqlClient;
using global::System.IO;

namespace Productivity_ASPWeb
{
    public partial class DM_Services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                BtnSearch_Click(null, EventArgs.Empty);
        }

        public SQLControl SQL = new SQLControl(GlobalVariables.strConnection);
        private int intSelectedRow;

        public void LoadGrid(string query = "")
        {
            if (string.IsNullOrEmpty(query))
            {
                // SQL.ExecuteQuery("Select * from Services where RecordActive = 'True';")
                SQL.ExecuteQuery("Select * from Services;");
            }
            else
            {
                SQL.ExecuteQuery(query);
            }

            if (SQL.HasException(true))
                return;
            dgvServices.DataSource = SQL.DBDS.Tables[0];
            if (dgvServices.Rows.Count > 0)
            {
                //dgvServices.Rows[0].Selected = true;
                dgvServices.SelectRow(intSelectedRow);
                dgvServices.SelectedIndex = intSelectedRow;

            }
            // SQL.DBDA.UpdateCommand = New SqlClient.SqlCommandBuilder(SQL.DBDA).GetUpdateCommand
            if (dgvServices.Rows.Count > 0)
            {
                DgvServices_SelectionChanged(null, EventArgs.Empty);

                // 0 [Employee_ID]
                dgvServices.Columns[0].HeaderText = "Credible ID";
                // dgvServices.Columns[0].Width = 50;
                // 1 [Employee_Name]
                dgvServices.Columns[1].HeaderText = "Employee Name";
                // dgvServices.Columns[1].Width = 50;
                // 2 [CPT_Code]
                dgvServices.Columns[2].HeaderText = "CPT Code";
                // dgvServices.Columns[2].Width = 50;
                // 3 [CPT_Modifier]
                dgvServices.Columns[3].HeaderText = "CPT Modifier";
                // dgvServices.Columns[3].Width = 50;
                // 4 [Client_ID]
                dgvServices.Columns[4].HeaderText = "Client ID";
                // dgvServices.Columns[4].Width = 75;
                // 5 [Client_Name]
                dgvServices.Columns[5].HeaderText = "Client Name";
                // dgvServices.Columns[5].Width = 130;
                // 6 [Service_ID]
                dgvServices.Columns[6].HeaderText = "Service ID";
                // dgvServices.Columns[6].Width = 130;
                // 7 [Service_Date]
                dgvServices.Columns[7].HeaderText = "Service Date";
                // dgvServices.Columns[7].Width = 60;
                // 8 [Service_Type]
                dgvServices.Columns[8].HeaderText = "Service Type";
                // dgvServices.Columns[8].Width = 55;
                // 9 [Program]
                dgvServices.Columns[9].HeaderText = "Program";
                // dgvServices.Columns[9].Width = 120;
                // 10[Location]
                dgvServices.Columns[10].HeaderText = "Location";
                // dgvServices.Columns[10].Width = 120;
                // 11[Merged_Units]
                dgvServices.Columns[11].HeaderText = "Units";
                // dgvServices.Columns[11].Width = 50;
                // 12[Merged_Duration]
                dgvServices.Columns[12].HeaderText = "Duration";
                // dgvServices.Columns[12].Width = 50;
                // 13[RecordActive]
                dgvServices.Columns[13].HeaderText = "Record Active";
                // dgvServices.Columns[13].Width = 50;
                // 14[CreatedBy]
                dgvServices.Columns[14].Visible = false;
                // 15[CreateDate]
                dgvServices.Columns[15].Visible = false;
                // 16[ModifiedBy]
                dgvServices.Columns[16].Visible = false;
                // 17[ModifiedDate]
                dgvServices.Columns[17].Visible = false;
                if (dgvServices.Rows.Count > 0)
                {
                    if (dgvServices.Rows.Count >= intSelectedRow)
                    {
                        dgvServices.SelectRow(intSelectedRow);
                        dgvServices.SelectedIndex = intSelectedRow;
                        dgvServices.SelectedRow.Focus();
                        //dgvServices.CurrentCell = dgvServices.Rows[intSelectedRow].Cells[1];
                        //dgvServices.FirstDisplayedScrollingRowIndex = dgvServices.SelectedRow.RowIndex;
                        DisplayValues();
                        //  EnableButtons();
                    }
                }
                else
                {
                    intSelectedRow = dgvServices.Rows.Count;
                    txtEmployee_ID.Text = "";
                    txtEmployee_Name.Text = "";
                    txtCPT_Code.Text = "";
                    txtCPT_Modifier.Text = "";
                    txtClient_ID.Text = "";
                    txtClient_Name.Text = "";
                    txtService_ID.Text = "";
                    txtService_Date.Text = "";
                    txtService_Type.Text = "";
                    txtProgram.Text = "";
                    txtLocation.Text = "";
                    txtMerged_Units.Text = "";
                    txtMerged_Duration.Text = "";
                    txtCreatedBy.Text = "";
                    txtCreateDate.Text = "";
                    txtModifiedBy.Text = "";
                    txtModifiedDate.Text = "";
                    chkbxRecordActive.Checked = false;
                }
            }
        }

        private void DgvServices_SelectionChanged(object sender, EventArgs e)
        {
            DisplayValues();
        }

        private void BtnSearch_Click(object p, EventArgs empty)
        {
            SQL.AddParam("@Employee_ID", txtSrchEmployee_ID.Text);
            SQL.AddParam("@Employee_Name", txtSrchEmployee_Name.Text);
            SQL.AddParam("@Program", txtSrchProgram.Text);
            SQL.AddParam("@Service_Date", txtSrchService_Date.Text);
            SQL.AddParam("@CPT_Code", txtSrchCPT_Code.Text);
            SQL.AddParam("@Location", txtSrchLocation.Text);
            if (chkbxRecordActive.Checked == true)
            {
                LoadGrid(@"select * from Services 
                            where (@Employee_ID = '' or Employee_ID = @Employee_ID)
                            and (@Employee_Name = '' or Employee_Name like '%' + @Employee_Name + '%')
                            and (@Program = '' or Program like '%' + @Program + '%')
                            and (@Service_Date = '' or Service_Date = @Service_Date)
                            and (@CPT_Code = '' or CPT_Code = @CPT_Code)
                            and (@Location = '' or Location like '%' + @Location + '%')                            
                            and RecordActive = 1
                            order by Employee_Name, Service_Date
                        ;");
            }
            else 
            {
                LoadGrid(@"select * from Services where (@Employee_ID = '' or Employee_ID = @Employee_ID) and (@Employee_Name = '' or Employee_Name like '%' + @Employee_Name + '%') and (@Program = '' or Program like '%' + @Program + '%') and (@Service_Date = '' or Service_Date = @Service_Date) and (@CPT_Code = '' or CPT_Code = @CPT_Code) and (@Location = '' or Location like '%' + @Location + '%') order by Employee_Name, Service_Date;");
                //LoadGrid(@"select * from Services 
                //            where (@Employee_ID = '' or Employee_ID = @Employee_ID)
                //            and (@Employee_Name = '' or Employee_Name like '%' + @Employee_Name + '%')
                //            and (@Program = '' or Program like '%' + @Program + '%')
                //            and (@Service_Date = '' or Service_Date = @Service_Date)
                //            and (@CPT_Code = '' or CPT_Code = @CPT_Code)
                //            and (@Location = '' or Location like '%' + @Location + '%')                            
                //            order by Employee_Name, Service_Date
                //        ;");
            }
            //throw new NotImplementedException();
        }

        private void DisplayValues()
        {
            if (dgvServices.Rows.Count > 0)
            {
                // 0 [Employee_ID]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[0].Text is object)
                {
                    txtEmployee_ID.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[0].Text.ToString(); // Services.Employee_ID
                }
                // 1 [Employee_Name]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[1].Text is object)
                {
                    txtEmployee_Name.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[1].Text.ToString(); // Services.Employee_Name
                }
                // 2 [CPT_Code]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[2].Text is object)
                {
                    txtCPT_Code.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[2].Text.ToString(); // Services.CPT_Code
                }
                // 3 [CPT_Modifier]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[3].Text is object)
                {
                    txtCPT_Modifier.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[3].Text.ToString(); // Services.CPT_Modifier
                }
                // 4 [Client_ID]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[4].Text is object)
                {
                    txtClient_ID.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[4].Text.ToString(); // Services.Client_ID
                }
                // 5 [Client_Name]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[5].Text is object)
                {
                    txtClient_Name.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[5].Text.ToString(); // Services.Client_Name
                }
                // 6 [Service_ID]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[6].Text is object)
                {
                    txtService_ID.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[6].Text.ToString(); // Services.Service_ID
                }
                // 7 [Service_Date]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[7].Text is object)
                {
                    txtService_Date.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[7].Text.ToString(); // Services.Service_Date
                }
                // 8 [Service_Type]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[8].Text is object)
                {
                    txtService_Type.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[8].Text.ToString(); // Services.Service_Type
                }
                // 9 [Program]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[9].Text is object)
                {
                    txtProgram.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[9].Text.ToString(); // Services.Program
                }
                // 10[Location]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[10].Text is object)
                {
                    txtLocation.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[10].Text.ToString(); // Services.Location
                }
                // 11[Merged_Units]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[11].Text is object)
                {
                    txtMerged_Units.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[11].Text.ToString(); // Services.Merged_Units
                }
                // 12[Merged_Duration]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[12].Text is object)
                {
                    txtMerged_Duration.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[12].Text.ToString(); // Services.Merged_Duration
                }
                // 13[RecordActive]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[13].Text is object)
                {
                    //chkbxRecordActive.Checked = Conversions.ToBoolean(dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[13].Text.ToString()); // Services.RecordActive
                    chkbxRecordActive.Checked = true; // Services.Merged_Duration
                }
                // 14[CreatedBy]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[14].Text is object)
                {
                    txtCreatedBy.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[14].Text.ToString(); // Services.CreatedBy
                }
                // 15[CreateDate]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[15].Text is object)
                {
                    txtCreateDate.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[15].Text.ToString(); // Services.CreateDate
                }
                // 16[ModifiedBy]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[16].Text is object)
                {
                    txtModifiedBy.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[16].Text.ToString(); // Services.ModifiedBy
                }
                // 17[ModifiedDate]
                if (dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[17].Text is object)
                {
                    txtModifiedDate.Text = dgvServices.Rows[dgvServices.SelectedRow.RowIndex].Cells[17].Text.ToString(); // Services.ModifiedDate
                }
            }
        } // DisplayValues
    }
}