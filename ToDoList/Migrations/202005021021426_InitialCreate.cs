namespace ToDoList.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Tags",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ToDoes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    Priority = c.Int(nullable: false),
                    isComplete = c.Boolean(nullable: false),
                    CategoryId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.ToDoTags",
                c => new
                {
                    ToDo_Id = c.Int(nullable: false),
                    Tag_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.ToDo_Id, t.Tag_Id })
                .ForeignKey("dbo.ToDoes", t => t.ToDo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.ToDo_Id)
                .Index(t => t.Tag_Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.ToDoTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.ToDoTags", "ToDo_Id", "dbo.ToDoes");
            DropForeignKey("dbo.ToDoes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ToDoTags", new[] { "Tag_Id" });
            DropIndex("dbo.ToDoTags", new[] { "ToDo_Id" });
            DropIndex("dbo.ToDoes", new[] { "CategoryId" });
            DropTable("dbo.ToDoTags");
            DropTable("dbo.ToDoes");
            DropTable("dbo.Tags");
            DropTable("dbo.Categories");
        }
    }
}