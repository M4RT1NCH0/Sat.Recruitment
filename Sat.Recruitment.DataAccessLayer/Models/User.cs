using System;

namespace Sat.Recruitment.DataAccessLayer.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                User u = (User)obj;
                return Email == u.Email || Phone == u.Phone || (Name == u.Name && Address == u.Address);
            }
        }
    }
}
