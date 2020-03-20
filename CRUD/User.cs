using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class User
    {
        public string Suffix { get; set; }
        public string Prefix { get; set; }
        public string UserID { get; set; }

        public User(string prefix, string suffix, string userID)
        {
            Prefix = prefix;
            UserID = userID;
            Suffix = suffix;
        }

        public override string ToString()
        {
            return "[Prefix = " + Prefix + ", Suffix = " + Suffix + ", userID = " + UserID
                + "]";
        }
    }
}
