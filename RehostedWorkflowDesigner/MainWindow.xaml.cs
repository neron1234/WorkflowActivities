﻿using System.Activities;
using System.Activities.Core.Presentation;
using System.Activities.Presentation;
using System.Activities.Presentation.Metadata;
using System.Activities.Presentation.Toolbox;
using System.Activities.Statements;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace RehostedWorkflowDesigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WorkflowDesigner wd;

        public MainWindow()
        {
            InitializeComponent();

            // Register the metadata  
            RegisterMetadata();

            // Add the WFF Designer  
            AddDesigner();

            this.AddToolBox();
            this.AddPropertyInspector();
        }

        private void AddPropertyInspector()
        {
            Grid.SetColumn(wd.PropertyInspectorView, 2);
            grid1.Children.Add(wd.PropertyInspectorView);
        }

        private ToolboxControl GetToolboxControl()
        {
            // Create the ToolBoxControl.  
            ToolboxControl ctrl = new ToolboxControl();

            // Create a category.  
            ToolboxCategory category = new ToolboxCategory("category1");

            // Create Toolbox items.  
            ToolboxItemWrapper tool1 =
                new ToolboxItemWrapper("System.Activities.Statements.Assign",
                typeof(Assign).Assembly.FullName, null, "Assign");

            ToolboxItemWrapper tool2 = new ToolboxItemWrapper("System.Activities.Statements.Sequence",
                typeof(Sequence).Assembly.FullName, null, "Sequence");

            // Add the Toolbox items to the category.  
            category.Add(tool1);
            category.Add(tool2);

            // Add the category to the ToolBox control.  
            ctrl.Categories.Add(category);
            return ctrl;
        }

        private void AddToolBox()
        {
            ToolboxControl tc = GetToolboxControl();
            Grid.SetColumn(tc, 0);
            grid1.Children.Add(tc);
        }

        private void AddDesigner()
        {
            //Create an instance of WorkflowDesigner class.  
            this.wd = new WorkflowDesigner();

            //Place the designer canvas in the middle column of the grid.  
            Grid.SetColumn(this.wd.View, 1);

            //Load a new Sequence as default.  
            this.wd.Load(new Sequence());

            //Add the designer canvas to the grid.  
            grid1.Children.Add(this.wd.View);
        }

        private void RegisterMetadata()
        {
            DesignerMetadata dm = new DesignerMetadata();
            dm.Register();
        }
    }
}
