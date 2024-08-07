using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    internal class Member : Person
    {
        public int MemberID { get; set; }

        public Member(int memberID, string name) : base(name)
        {
            MemberID = memberID;
        }
    }

}
