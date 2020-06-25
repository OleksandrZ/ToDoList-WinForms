namespace ToDoList.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class v101 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ToDoes", new[] { "CategoryId" });
            AlterColumn("dbo.ToDoes", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.ToDoes", "CategoryId");
            AddForeignKey("dbo.ToDoes", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.ToDoes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ToDoes", new[] { "CategoryId" });
            AlterColumn("dbo.ToDoes", "CategoryId", c => c.Int());
            CreateIndex("dbo.ToDoes", "CategoryId");
            AddForeignKey("dbo.ToDoes", "CategoryId", "dbo.Categories", "Id");
        }
    }
}