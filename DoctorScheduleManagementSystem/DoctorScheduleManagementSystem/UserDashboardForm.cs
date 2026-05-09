using System.Drawing;
using System.Windows.Forms;
namespace DoctorScheduleManagementSystem
{
    public class UserDashboardForm : Form
    {
        public UserDashboardForm()
        {
            Text="Patient Dashboard"; Size=new Size(540,360); StartPosition=FormStartPosition.CenterScreen;
            Label title=new Label{Text="Patient Dashboard",Font=new Font("Arial",18,FontStyle.Bold),AutoSize=true,Location=new Point(160,35)};
            Button btnBook=new Button{Text="View Doctors / Book Appointment",Location=new Point(135,110),Width=255,Height=42}; btnBook.Click+=(s,e)=>new AppointmentBookingForm().ShowDialog();
            Button btnReview=new Button{Text="Give Doctor Review",Location=new Point(135,170),Width=255,Height=42}; btnReview.Click+=(s,e)=>new ReviewForm().ShowDialog();
            Button btnLogout=new Button{Text="Logout",Location=new Point(135,235),Width=255,Height=42}; btnLogout.Click+=(s,e)=>Close();
            Controls.AddRange(new Control[]{title,btnBook,btnReview,btnLogout});
        }
    }
}
