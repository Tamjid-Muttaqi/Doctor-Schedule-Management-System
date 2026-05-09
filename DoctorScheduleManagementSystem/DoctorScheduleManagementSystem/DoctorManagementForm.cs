using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace DoctorScheduleManagementSystem
{
    public class DoctorManagementForm : Form
    {
        DataGridView grid; TextBox txtId, txtName, txtSpec, txtLocation; bool readOnly;
        public DoctorManagementForm(bool readOnlyMode=false)
        {
            readOnly=readOnlyMode; Text=readOnly?"View Doctors":"Doctor Management"; Size=new Size(820,530); StartPosition=FormStartPosition.CenterScreen;
            Controls.Add(new Label{Text=Text,Font=new Font("Arial",18,FontStyle.Bold),AutoSize=true,Location=new Point(290,20)});
            txtId=AddTextBox("Doctor ID",75,true); txtName=AddTextBox("Name",115,false); txtSpec=AddTextBox("Specialization",155,false); txtLocation=AddTextBox("Location",195,false);
            Button btnAdd=new Button{Text="Add",Location=new Point(445,75),Width=95}; Button btnUpdate=new Button{Text="Update",Location=new Point(445,115),Width=95}; Button btnDelete=new Button{Text="Delete",Location=new Point(445,155),Width=95}; Button btnClear=new Button{Text="Clear",Location=new Point(445,195),Width=95};
            btnAdd.Click+=BtnAdd_Click; btnUpdate.Click+=BtnUpdate_Click; btnDelete.Click+=BtnDelete_Click; btnClear.Click+=(s,e)=>ClearFields();
            grid=new DataGridView{Location=new Point(40,260),Size=new Size(730,210),ReadOnly=true,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill}; grid.CellClick+=Grid_CellClick;
            Controls.AddRange(new Control[]{btnAdd,btnUpdate,btnDelete,btnClear,grid});
            if(readOnly){txtName.Enabled=txtSpec.Enabled=txtLocation.Enabled=false; btnAdd.Enabled=btnUpdate.Enabled=btnDelete.Enabled=btnClear.Enabled=false;}
            LoadDoctors();
        }
        TextBox AddTextBox(string label,int y,bool disabled){Label l=new Label{Text=label,Location=new Point(60,y+5),AutoSize=true};TextBox t=new TextBox{Location=new Point(185,y),Width=210,Enabled=!disabled};Controls.Add(l);Controls.Add(t);return t;}
        void LoadDoctors(){grid.DataSource=Db.GetData("SELECT * FROM Doctors");}
        void Grid_CellClick(object sender,DataGridViewCellEventArgs e){if(e.RowIndex<0)return;txtId.Text=grid.Rows[e.RowIndex].Cells["DoctorId"].Value.ToString();txtName.Text=grid.Rows[e.RowIndex].Cells["DoctorName"].Value.ToString();txtSpec.Text=grid.Rows[e.RowIndex].Cells["Specialization"].Value.ToString();txtLocation.Text=grid.Rows[e.RowIndex].Cells["ChamberLocation"].Value.ToString();}
        void BtnAdd_Click(object sender,EventArgs e){if(txtName.Text.Trim()==""){MessageBox.Show("Doctor name is required.");return;} bool ok=Db.Execute("INSERT INTO Doctors(DoctorName,Specialization,ChamberLocation) VALUES(@n,@s,@l)",new SqlParameter("@n",txtName.Text.Trim()),new SqlParameter("@s",txtSpec.Text.Trim()),new SqlParameter("@l",txtLocation.Text.Trim()));if(ok){LoadDoctors();ClearFields();}}
        void BtnUpdate_Click(object sender,EventArgs e){if(txtId.Text==""){MessageBox.Show("Select a doctor first.");return;} bool ok=Db.Execute("UPDATE Doctors SET DoctorName=@n, Specialization=@s, ChamberLocation=@l WHERE DoctorId=@id",new SqlParameter("@n",txtName.Text.Trim()),new SqlParameter("@s",txtSpec.Text.Trim()),new SqlParameter("@l",txtLocation.Text.Trim()),new SqlParameter("@id",txtId.Text));if(ok){LoadDoctors();ClearFields();}}
        void BtnDelete_Click(object sender,EventArgs e){if(txtId.Text==""){MessageBox.Show("Select a doctor first.");return;} Db.Execute("DELETE FROM Reviews WHERE DoctorId=@id",new SqlParameter("@id",txtId.Text)); Db.Execute("DELETE FROM Payments WHERE AppointmentId IN (SELECT AppointmentId FROM Appointments WHERE DoctorId=@id)",new SqlParameter("@id",txtId.Text)); Db.Execute("DELETE FROM Appointments WHERE DoctorId=@id",new SqlParameter("@id",txtId.Text)); Db.Execute("DELETE FROM DoctorSchedule WHERE DoctorId=@id",new SqlParameter("@id",txtId.Text)); bool ok=Db.Execute("DELETE FROM Doctors WHERE DoctorId=@id",new SqlParameter("@id",txtId.Text)); if(ok){LoadDoctors();ClearFields();}}
        void ClearFields(){txtId.Clear();txtName.Clear();txtSpec.Clear();txtLocation.Clear();}
    }
}
