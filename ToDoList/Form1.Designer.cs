namespace ToDoList
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toDoListView = new System.Windows.Forms.ListView();
            this.ToDoName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Priority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FinalDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isComplete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddToDo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryFilter = new System.Windows.Forms.CheckedListBox();
            this.tagsFilter = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.deleteTag = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toDoListView
            // 
            this.toDoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ToDoName,
            this.Description,
            this.Category,
            this.Priority,
            this.FinalDate,
            this.isComplete,
            this.Tags});
            this.toDoListView.HideSelection = false;
            this.toDoListView.Location = new System.Drawing.Point(12, 11);
            this.toDoListView.MultiSelect = false;
            this.toDoListView.Name = "toDoListView";
            this.toDoListView.Size = new System.Drawing.Size(789, 321);
            this.toDoListView.TabIndex = 1;
            this.toDoListView.UseCompatibleStateImageBehavior = false;
            this.toDoListView.View = System.Windows.Forms.View.Details;
            this.toDoListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.toDoListView_MouseClick);
            // 
            // ToDoName
            // 
            this.ToDoName.Text = "Name";
            this.ToDoName.Width = 75;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 126;
            // 
            // Category
            // 
            this.Category.Text = "Category";
            this.Category.Width = 96;
            // 
            // Priority
            // 
            this.Priority.Text = "Priority";
            this.Priority.Width = 45;
            // 
            // FinalDate
            // 
            this.FinalDate.Text = "Complete before";
            this.FinalDate.Width = 124;
            // 
            // isComplete
            // 
            this.isComplete.Text = "Status";
            this.isComplete.Width = 69;
            // 
            // Tags
            // 
            this.Tags.Text = "Tags";
            this.Tags.Width = 224;
            // 
            // AddToDo
            // 
            this.AddToDo.Location = new System.Drawing.Point(12, 339);
            this.AddToDo.Name = "AddToDo";
            this.AddToDo.Size = new System.Drawing.Size(100, 37);
            this.AddToDo.TabIndex = 2;
            this.AddToDo.Text = "Add new ToDo";
            this.AddToDo.UseVisualStyleBackColor = true;
            this.AddToDo.Click += new System.EventHandler(this.AddToDo_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "Add category";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Delete Category";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // categoryFilter
            // 
            this.categoryFilter.FormattingEnabled = true;
            this.categoryFilter.Location = new System.Drawing.Point(432, 338);
            this.categoryFilter.Name = "categoryFilter";
            this.categoryFilter.Size = new System.Drawing.Size(120, 94);
            this.categoryFilter.TabIndex = 6;
            this.categoryFilter.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.categoryFilter_ItemCheck);
            // 
            // tagsFilter
            // 
            this.tagsFilter.FormattingEnabled = true;
            this.tagsFilter.Items.AddRange(new object[] {
            "No tags"});
            this.tagsFilter.Location = new System.Drawing.Point(601, 338);
            this.tagsFilter.Name = "tagsFilter";
            this.tagsFilter.Size = new System.Drawing.Size(120, 94);
            this.tagsFilter.TabIndex = 7;
            this.tagsFilter.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.tagsFilter_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(564, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tags";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sort by:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(727, 338);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 382);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 36);
            this.button4.TabIndex = 12;
            this.button4.Text = "Add Tag";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // deleteTag
            // 
            this.deleteTag.Location = new System.Drawing.Point(224, 339);
            this.deleteTag.Name = "deleteTag";
            this.deleteTag.Size = new System.Drawing.Size(100, 37);
            this.deleteTag.TabIndex = 13;
            this.deleteTag.Text = "Delete Tag";
            this.deleteTag.UseVisualStyleBackColor = true;
            this.deleteTag.Click += new System.EventHandler(this.deleteTag_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 450);
            this.Controls.Add(this.deleteTag);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tagsFilter);
            this.Controls.Add(this.categoryFilter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddToDo);
            this.Controls.Add(this.toDoListView);
            this.Name = "Form1";
            this.Text = "To Do List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView toDoListView;
        private System.Windows.Forms.ColumnHeader ToDoName;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Category;
        private System.Windows.Forms.ColumnHeader Priority;
        private System.Windows.Forms.ColumnHeader FinalDate;
        private System.Windows.Forms.ColumnHeader isComplete;
        private System.Windows.Forms.ColumnHeader Tags;
        private System.Windows.Forms.Button AddToDo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox categoryFilter;
        private System.Windows.Forms.CheckedListBox tagsFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button deleteTag;
    }
}

