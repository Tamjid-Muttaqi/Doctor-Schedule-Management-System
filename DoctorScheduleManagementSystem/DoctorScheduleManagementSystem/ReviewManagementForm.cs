using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace DoctorScheduleManagementSystem
{
    public class ReviewManagementForm : Form
    {
        DataGridView grid;
        public ReviewManagementForm(){Text="Public Reviews and Doctor Removal";Size=new Size(920,520);StartPosition=FormStartPosition.CenterScreen;Label title=new Label{Text="Public Reviews - Super Admin",Font=new Font("Arial",18,FontStyle.Bold),AutoSize=true,Location=new Point(270,25)};Button btnRefresh=new Button{Text="Refresh",Location=new Point(285,80),Width=120};Button btnRemoveDoctor=new Button{Text="Remove Selected Doctor",Location=new Point(425,80),Width=190};btnRefresh.Click+=(s,e)=>LoadReviews();btnRemoveDoctor.Click+=BtnRemoveDoctor_Click;grid=new DataGridView{Location=new Point(40,140),Size=new Size(830,300),ReadOnly=true,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill};Controls.AddRange(new Control[]{title,btnRefresh,btnRemoveDoctor,grid});LoadReviews();}
        void LoadReviews(){grid.DataSource=Db.GetData(@"SELECT r.ReviewId,r.DoctorId,d.DoctorName,u.FullName AS PatientName,r.Rating,r.Comment FROM Reviews r INNER JOIN Doctors d ON r.DoctorId=d.DoctorId INNER JOIN Users u ON r.UserId=u.UserId ORDER BY r.Rating ASC");}
        void BtnRemoveDoctor_Click(object sender,EventArgs e){if(grid.CurrentRow==null){MessageBox.Show("Select a review row first.");return;}int doctorId=Convert.ToInt32(grid.CurrentRow.Cells["DoctorId"].Value);DialogResult result=MessageBox.Show("Remove this doctor based on public review?","Confirm",MessageBoxButtons.YesNo);if(result!=DialogResult.Yes)return;Db.Execute("DELETE FROM Reviews WHERE DoctorId=@id",new SqlParameter("@id",doctorId));Db.Execute("DELETE FROM Payments WHERE AppointmentId IN (SELECT AppointmentId FROM Appointments WHERE DoctorId=@id)",new SqlParameter("@id",doctorId));Db.Execute("DELETE FROM Appointments WHERE DoctorId=@id",new SqlParameter("@id",doctorId));Db.Execute("DELETE FROM DoctorSchedule WHERE DoctorId=@id",new SqlParameter("@id",doctorId));bool ok=Db.Execute("DELETE FROM Doctors WHERE DoctorId=@id",new SqlParameter("@id",doctorId));if(ok){MessageBox.Show("Doctor removed successfully.");LoadReviews();}}
    }
}
