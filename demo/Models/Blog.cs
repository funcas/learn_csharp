using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.Models
{
	[Table("blogs")]
	public class Blog
	{
		public Blog(string title, string content)
		{
			Title = title;
			Content = content;
		}

		[Column(TypeName = "INTEGER")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
		public int BlogId { get; set; }
		[Column(TypeName = "varchar(32)")]
		public string Title { get; set; }
		[Column(TypeName = "varchar(255)")]
		public string Content { get; set; }
	}
}

