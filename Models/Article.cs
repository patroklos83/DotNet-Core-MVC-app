using Microsoft.Build.Framework;
using NHibernate;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System.Xml.Linq;

namespace WebApplicationExample.Models
{
    public class Article
    {
        public virtual Guid Id { get; set; }
        public virtual string? Title { get; set; }
        public virtual string? Author { get; set; }
        public virtual int IsDeleted { get; set; }
    }

    public class ArticleMap : ClassMapping<Article>
    {
        public ArticleMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Guid);

                //x.Generator(Generators.Sequence, g => g.Params(new
                //{
                //    sequence = "sqlite_sequence",
                //    schema = string.Empty,
                //    catalog = string.Empty,
                //    parameters = string.Empty, // driver-specific DDL string to be appended to create command
                //}));

                x.Type(NHibernateUtil.Guid);
                x.Column("Id");
                x.UnsavedValue(Guid.Empty);
            });

            Property(b => b.Title, x =>
            {
                x.Length(300);
                x.Type(NHibernateUtil.StringClob);
                x.NotNullable(true);
            });

            Property(b => b.Author, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.StringClob);
                x.NotNullable(true);
            });

            Property(c => c.IsDeleted, x =>
            {
                x.Column("IsDeleted");
            });

            Table("Articles");
        }
    }
}
