using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public static class MemberDataForTest
    {
        public static List<object[]> MemberData()
        {
            List<object[]> memberData = new List<object[]>();

            memberData.Add(new object[] { 2, 5, 10 });
            memberData.Add(new object[] { 20, 5, 100 });
            memberData.Add(new object[] { 10, 2, 20 });
            
            return memberData;
        }
    }
}
