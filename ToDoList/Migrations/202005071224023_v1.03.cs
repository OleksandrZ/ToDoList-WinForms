namespace ToDoList.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class v103 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.ToDoes", "StatusId", c => c.Int(nullable: true));
            CreateIndex("dbo.ToDoes", "StatusId");
            AddForeignKey("dbo.ToDoes", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            DropColumn("dbo.ToDoes", "isComplete");
        }

        public override void Down()
        {
            AddColumn("dbo.ToDoes", "isComplete", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ToDoes", "StatusId", "dbo.Status");
            DropIndex("dbo.ToDoes", new[] { "StatusId" });
            DropColumn("dbo.ToDoes", "StatusId");
            DropTable("dbo.Status");
        }
    }
}