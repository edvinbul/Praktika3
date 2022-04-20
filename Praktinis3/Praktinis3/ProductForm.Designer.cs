
namespace Praktinis3
{
    partial class ProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rentButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.costLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.commentariesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.commentaryPanel = new System.Windows.Forms.Panel();
            this.deleteCommentaryButton = new System.Windows.Forms.Button();
            this.commentaryTextLabel = new System.Windows.Forms.Label();
            this.commentaryNameLabel = new System.Windows.Forms.Label();
            this.addCommentaryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.commentariesPanel.SuspendLayout();
            this.commentaryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(24, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(338, 256);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // rentButton
            // 
            this.rentButton.Location = new System.Drawing.Point(58, 313);
            this.rentButton.Name = "rentButton";
            this.rentButton.Size = new System.Drawing.Size(98, 23);
            this.rentButton.TabIndex = 4;
            this.rentButton.Text = "Rent";
            this.rentButton.UseVisualStyleBackColor = true;
            this.rentButton.Click += new System.EventHandler(this.likeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(690, 12);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(98, 23);
            this.deleteButton.TabIndex = 32;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.nameLabel.Location = new System.Drawing.Point(375, 51);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(64, 25);
            this.nameLabel.TabIndex = 33;
            this.nameLabel.Text = "Name";
            this.nameLabel.Click += new System.EventHandler(this.nameLabel_Click);
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.categoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.categoryLabel.Location = new System.Drawing.Point(375, 91);
            this.categoryLabel.MaximumSize = new System.Drawing.Size(200, 0);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(92, 25);
            this.categoryLabel.TabIndex = 34;
            this.categoryLabel.Text = "Category";
            this.categoryLabel.Click += new System.EventHandler(this.categoryLabel_Click);
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.costLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.costLabel.Location = new System.Drawing.Point(624, 91);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(53, 25);
            this.costLabel.TabIndex = 35;
            this.costLabel.Text = "Cost";
            this.costLabel.Click += new System.EventHandler(this.costLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(375, 136);
            this.label1.MaximumSize = new System.Drawing.Size(200, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 36;
            this.label1.Text = "Description:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionTextBox.Location = new System.Drawing.Point(380, 186);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.descriptionTextBox.Size = new System.Drawing.Size(400, 150);
            this.descriptionTextBox.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(38, 352);
            this.label2.MaximumSize = new System.Drawing.Size(200, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 39;
            this.label2.Text = "Commentaries:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // commentariesPanel
            // 
            this.commentariesPanel.AutoScroll = true;
            this.commentariesPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.commentariesPanel.Controls.Add(this.commentaryPanel);
            this.commentariesPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.commentariesPanel.Location = new System.Drawing.Point(40, 380);
            this.commentariesPanel.Name = "commentariesPanel";
            this.commentariesPanel.Size = new System.Drawing.Size(740, 360);
            this.commentariesPanel.TabIndex = 40;
            this.commentariesPanel.WrapContents = false;
            this.commentariesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.commentariesPanel_Paint);
            // 
            // commentaryPanel
            // 
            this.commentaryPanel.AutoSize = true;
            this.commentaryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commentaryPanel.Controls.Add(this.deleteCommentaryButton);
            this.commentaryPanel.Controls.Add(this.commentaryTextLabel);
            this.commentaryPanel.Controls.Add(this.commentaryNameLabel);
            this.commentaryPanel.Location = new System.Drawing.Point(3, 3);
            this.commentaryPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.commentaryPanel.MaximumSize = new System.Drawing.Size(700, 2);
            this.commentaryPanel.MinimumSize = new System.Drawing.Size(700, 50);
            this.commentaryPanel.Name = "commentaryPanel";
            this.commentaryPanel.Size = new System.Drawing.Size(700, 50);
            this.commentaryPanel.TabIndex = 0;
            // 
            // deleteCommentaryButton
            // 
            this.deleteCommentaryButton.Location = new System.Drawing.Point(599, 5);
            this.deleteCommentaryButton.Name = "deleteCommentaryButton";
            this.deleteCommentaryButton.Size = new System.Drawing.Size(98, 23);
            this.deleteCommentaryButton.TabIndex = 36;
            this.deleteCommentaryButton.Text = "Delete";
            this.deleteCommentaryButton.UseVisualStyleBackColor = true;
            // 
            // commentaryTextLabel
            // 
            this.commentaryTextLabel.AutoSize = true;
            this.commentaryTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commentaryTextLabel.Location = new System.Drawing.Point(10, 35);
            this.commentaryTextLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.commentaryTextLabel.MaximumSize = new System.Drawing.Size(650, 0);
            this.commentaryTextLabel.MinimumSize = new System.Drawing.Size(650, 0);
            this.commentaryTextLabel.Name = "commentaryTextLabel";
            this.commentaryTextLabel.Size = new System.Drawing.Size(650, 20);
            this.commentaryTextLabel.TabIndex = 35;
            this.commentaryTextLabel.Text = "Text";
            // 
            // commentaryNameLabel
            // 
            this.commentaryNameLabel.AutoSize = true;
            this.commentaryNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commentaryNameLabel.Location = new System.Drawing.Point(10, 5);
            this.commentaryNameLabel.MaximumSize = new System.Drawing.Size(500, 30);
            this.commentaryNameLabel.Name = "commentaryNameLabel";
            this.commentaryNameLabel.Size = new System.Drawing.Size(51, 20);
            this.commentaryNameLabel.TabIndex = 34;
            this.commentaryNameLabel.Text = "Name";
            // 
            // addCommentaryButton
            // 
            this.addCommentaryButton.Location = new System.Drawing.Point(629, 351);
            this.addCommentaryButton.Name = "addCommentaryButton";
            this.addCommentaryButton.Size = new System.Drawing.Size(150, 23);
            this.addCommentaryButton.TabIndex = 41;
            this.addCommentaryButton.Text = "Add a commentary";
            this.addCommentaryButton.UseVisualStyleBackColor = true;
            this.addCommentaryButton.Click += new System.EventHandler(this.addCommentaryButton_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 761);
            this.Controls.Add(this.addCommentaryButton);
            this.Controls.Add(this.commentariesPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.rentButton);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 800);
            this.MinimumSize = new System.Drawing.Size(816, 800);
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.commentariesPanel.ResumeLayout(false);
            this.commentariesPanel.PerformLayout();
            this.commentaryPanel.ResumeLayout(false);
            this.commentaryPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button rentButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel commentariesPanel;
        private System.Windows.Forms.Panel commentaryPanel;
        private System.Windows.Forms.Button deleteCommentaryButton;
        private System.Windows.Forms.Label commentaryTextLabel;
        private System.Windows.Forms.Label commentaryNameLabel;
        private System.Windows.Forms.Button addCommentaryButton;
    }
}