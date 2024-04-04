using System.Security.Cryptography.X509Certificates;

namespace SMS.Models
{
    public class Courses
    {
        private int CoursesId;
        public string CoursesName;

        public int Courseid
        {
            get { return CoursesId; }
            set { CoursesId = value; }
        }
    }
}
