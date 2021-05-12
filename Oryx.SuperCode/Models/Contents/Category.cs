using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oryx.SuperCode.Models.Contents
{
    public class Category
    {
        // Id 默认的表的主键
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        //一对多外键关联
        public virtual List<Article> Articles { get; set; }

    }
}
