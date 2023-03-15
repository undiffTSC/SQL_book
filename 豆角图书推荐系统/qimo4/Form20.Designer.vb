<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form20
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form20))
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.AdmNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdmNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdmSexDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdmAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdmTelephoneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PasswordDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdministratorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.图书推荐系统DataSet = New qimo4.图书推荐系统DataSet()
        Me.AdministratorTableAdapter = New qimo4.图书推荐系统DataSetTableAdapters.AdministratorTableAdapter()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdministratorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.图书推荐系统DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.Font = New System.Drawing.Font("楷体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button4.Location = New System.Drawing.Point(677, 205)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(105, 38)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "确认更新"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Font = New System.Drawing.Font("楷体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button2.Location = New System.Drawing.Point(677, 131)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 39)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "删除管理员"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("楷体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button1.Location = New System.Drawing.Point(677, 64)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(139, 38)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "添加新管理员"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AdmNoDataGridViewTextBoxColumn, Me.AdmNameDataGridViewTextBoxColumn, Me.AdmSexDataGridViewTextBoxColumn, Me.AdmAddressDataGridViewTextBoxColumn, Me.AdmTelephoneDataGridViewTextBoxColumn, Me.PasswordDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.AdministratorBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(72, 64)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 27
        Me.DataGridView1.Size = New System.Drawing.Size(608, 394)
        Me.DataGridView1.TabIndex = 6
        '
        'AdmNoDataGridViewTextBoxColumn
        '
        Me.AdmNoDataGridViewTextBoxColumn.DataPropertyName = "AdmNo"
        Me.AdmNoDataGridViewTextBoxColumn.HeaderText = "AdmNo"
        Me.AdmNoDataGridViewTextBoxColumn.Name = "AdmNoDataGridViewTextBoxColumn"
        '
        'AdmNameDataGridViewTextBoxColumn
        '
        Me.AdmNameDataGridViewTextBoxColumn.DataPropertyName = "AdmName"
        Me.AdmNameDataGridViewTextBoxColumn.HeaderText = "AdmName"
        Me.AdmNameDataGridViewTextBoxColumn.Name = "AdmNameDataGridViewTextBoxColumn"
        '
        'AdmSexDataGridViewTextBoxColumn
        '
        Me.AdmSexDataGridViewTextBoxColumn.DataPropertyName = "AdmSex"
        Me.AdmSexDataGridViewTextBoxColumn.HeaderText = "AdmSex"
        Me.AdmSexDataGridViewTextBoxColumn.Name = "AdmSexDataGridViewTextBoxColumn"
        '
        'AdmAddressDataGridViewTextBoxColumn
        '
        Me.AdmAddressDataGridViewTextBoxColumn.DataPropertyName = "AdmAddress"
        Me.AdmAddressDataGridViewTextBoxColumn.HeaderText = "AdmAddress"
        Me.AdmAddressDataGridViewTextBoxColumn.Name = "AdmAddressDataGridViewTextBoxColumn"
        '
        'AdmTelephoneDataGridViewTextBoxColumn
        '
        Me.AdmTelephoneDataGridViewTextBoxColumn.DataPropertyName = "AdmTelephone"
        Me.AdmTelephoneDataGridViewTextBoxColumn.HeaderText = "AdmTelephone"
        Me.AdmTelephoneDataGridViewTextBoxColumn.Name = "AdmTelephoneDataGridViewTextBoxColumn"
        '
        'PasswordDataGridViewTextBoxColumn
        '
        Me.PasswordDataGridViewTextBoxColumn.DataPropertyName = "Password"
        Me.PasswordDataGridViewTextBoxColumn.HeaderText = "Password"
        Me.PasswordDataGridViewTextBoxColumn.Name = "PasswordDataGridViewTextBoxColumn"
        '
        'AdministratorBindingSource
        '
        Me.AdministratorBindingSource.DataMember = "Administrator"
        Me.AdministratorBindingSource.DataSource = Me.图书推荐系统DataSet
        '
        '图书推荐系统DataSet
        '
        Me.图书推荐系统DataSet.DataSetName = "图书推荐系统DataSet"
        Me.图书推荐系统DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AdministratorTableAdapter
        '
        Me.AdministratorTableAdapter.ClearBeforeFill = True
        '
        'Form20
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(868, 513)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form20"
        Me.Text = "管理员设置"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdministratorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.图书推荐系统DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button4 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents 图书推荐系统DataSet As 图书推荐系统DataSet
    Friend WithEvents AdministratorBindingSource As BindingSource
    Friend WithEvents AdministratorTableAdapter As 图书推荐系统DataSetTableAdapters.AdministratorTableAdapter
    Friend WithEvents AdmNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AdmNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AdmSexDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AdmAddressDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AdmTelephoneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PasswordDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
