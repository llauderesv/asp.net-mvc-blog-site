using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BlogMoto.Models
{
    public class Blog
    {
        [Key]
        public long blogId { get; set; }

        [Required]
        [Display(Name="Title")]
        public string title { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Content must not be exceeding 1000 characters")]
        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date publish")]
        [Column(TypeName = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")] // Date format
        public DateTime datePublish { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "URL")]
        [StringLength(400)]
        public string url { get; set; }

        [Display(Name = "Tags")]
        [RegularExpression(@"\w{3,}(,\w{3,})*\b", ErrorMessage = "Each tag only accept atleast 3 characters and only separted by comma")]
        public string tags { get; set; }

        [Display(Name = "Author")]
        [RegularExpression(@"\w{1,}")]
        public string author { get; set; }

        [Display(Name = "Created by")]
        [RegularExpression(@"\d+", ErrorMessage="Created by must be an integer value")]
        [DataType(DataType.Text)]
        public long createdBy { get; set; }

        [Display(Name = "Modified by")]
        [RegularExpression(@"\d+", ErrorMessage = "Modified by must be an integer value")]
        [DataType(DataType.Text)]
        public long modifiedBy { get; set; }

        [Display(Name = "Date created")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")] // Date format
        [Column(TypeName = "DateTime2")]
        public DateTime? dateCreated { get; set; }

        [Display(Name = "Date Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")] // Date format
        [Column(TypeName = "DateTime2")]
        public DateTime? dateModified { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set; }
    }
}