using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Oryx.SuperCode.Models.Contents
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }

        public Guid ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

        ////父级
        //public Guid ParentId { get; set; }

        //[ForeignKey("ParentId")]
        //public virtual Comment Parent { get; set; }

        //子级
        public virtual List<Comment> Children { get; set; }
    }
}
