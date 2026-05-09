using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace DoctorScheduleManagementSystem
{
    public class ReviewForm : Form
    {
        ComboBox cmbDoctor,cmbRating; TextBox txtComment;
        public ReviewForm(){Text="Give Doctor Review";Size=new Size(500,380);StartPosition=FormStartPosition.CenterScreen;Label title=new Label{Text="Give Doctor Review",Font=new Font("Arial",18,FontStyle.Bold),AutoSize=true,Location=new Point(135,30)};Label lDoc=new Label{Text="Doctor",Location=new Point(70,105),AutoSize=true};cmbDoctor=new ComboBox{Location=new Point(170,100),Width=220,DropDownStyle=ComboBoxStyle.DropDownList};Label lRating=new Label{Text="Rating",Location=new Point(70,150),AutoSize=true};cmbRating=new ComboBox{Location=new Point(170,145),Width=220,DropDownStyle=ComboBoxStyle.DropDownList};cmbRating.Items.AddRange(new string[]{"1","2","3","4","5"});Label lComment=new Label{Text="Comment",Location=new Point(70,195),AutoSize=true};txtComment=new TextBox{Location=new Point(170,190),Width=220,Height=70,Multiline=true};Button btnSave=new Button{Text="Submit Review",Location=new Point(190,285),Width=130};btnSave.Click+=BtnSave_Click;Controls.AddRange(new Control[]{title,lDoc,cmbDoctor,lRating,cmbRating,lComment,txtComment,btnSave});LoadDoctors();}
        void LoadDoctors(){DataTable dt=Db.GetData("SELECT DoctorId,DoctorName FROM Doctors");cmbDoctor.DataSource=dt;cmbDoctor.DisplayMember="DoctorName";cmbDoctor.ValueMember="DoctorId";}
        void BtnSave_Click(object sender,System.EventArgs e){if(cmbDoctor.SelectedValue==null||cmbRating.Text==""){MessageBox.Show("Select doctor and rating.");return;}bool ok=Db.Execute(@"INSERT INTO Reviews(UserId,DoctorId,Rating,Comment) VALUES(@u,@d,@r,@c)",new SqlParameter("@u",AppSession.UserId),new SqlParameter("@d",cmbDoctor.SelectedValue),new SqlParameter("@r",cmbRating.Text),new SqlParameter("@c",txtComment.Text));if(ok){MessageBox.Show("Review submitted.");Close();}}
    }
}
