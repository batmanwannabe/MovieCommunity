using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class BoardsModel
    {
        public int BoardId { get; set; }
        public string UserName { get; set; }
        public int CommunityId { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
