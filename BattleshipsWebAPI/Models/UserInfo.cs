using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BattleshipsWebAPI
{
    public class UserInfo
    {
        public string Username { get; set; }
        public Guid? PublicId { get; set; }
    }
}