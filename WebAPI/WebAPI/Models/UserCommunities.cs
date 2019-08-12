using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class UserCommunities
    {
        public string UserName { get; set; }
        public int CommunityId { get; set; }
        public string Genre { get; set; }
    }
}
