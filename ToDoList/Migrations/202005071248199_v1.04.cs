namespace ToDoList.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class v104 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoes", "StatusId", "dbo.Status");
            DropIndex("dbo.ToDoes", new[] { "StatusId" });
            AlterColumn("dbo.ToDoes", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.ToDoes", "StatusId");
            AddForeignKey("dbo.ToDoes", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.ToDoes", "StatusId", "dbo.Status");
            DropIndex("dbo.ToDoes", new[] { "StatusId" });
            AlterColumn("dbo.ToDoes", "StatusId", c => c.Int());
            CreateIndex("dbo.ToDoes", "StatusId");
            AddForeignKey("dbo.ToDoes", "StatusId", "dbo.Status", "Id");
        }
    }
}