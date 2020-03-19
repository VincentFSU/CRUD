using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class User
    {
        string suffix;
        string prefix;
        string userID;

        public User(string prefix, string suffix, string userID)
        {
            this.prefix = prefix;
            this.suffix = suffix;
            this.userID = userID;
        }

        public string getPrefix()
        {
            return this.prefix;
        }

        public string getSuffix()
        {
            return this.suffix;
        }

        public string getUserID()
        {
            return this.userID;
        }

        public void setPrefix(string prefix)
        {
            this.prefix = prefix;
        }

        public void setSuffix(string suffix)
        {
            this.suffix = suffix;
        }

        public void setUserID(string userID)
        {
            this.userID = userID;
        }

        public string tostring()
        {
            return "[Prefix == " + prefix + ", Suffix = " + suffix + ", userID = " + userID
                + "]";
        }
    }
}
