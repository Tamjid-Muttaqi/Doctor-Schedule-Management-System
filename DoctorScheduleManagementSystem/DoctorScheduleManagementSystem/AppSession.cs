namespace DoctorScheduleManagementSystem
{
    public static class AppSession
    {
        public static int UserId { get; set; }
        public static string FullName { get; set; }
        public static string Role { get; set; }
        public static void Clear() { UserId = 0; FullName = ""; Role = ""; }
    }
}
