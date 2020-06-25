namespace ToDoList.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoes", "FinalDate", c => c.DateTime());
        }

        public override void Down()
        {
            DropColumn("dbo.ToDoes", "FinalDate");
        }
    }
}