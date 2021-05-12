using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oryx.SuperCode.Models.Contents
{
    public class Article
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }


        [ForeignKey("CategoryId")]
        //关联 Category
        public virtual Category Category { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        //=>ApplicationUser.Id string
        public string Author { get; set; }

        public string AuthorId { get; set; }

        //关联Comment 表
        public virtual List<Comment> Comments { get; set; }

        public DateTime CreateTime { get; set; }
        public int Like { get; set; }
        public int Favorite { get; set; }

    }
}
