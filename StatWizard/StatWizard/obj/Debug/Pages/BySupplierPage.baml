   M S B A M L   `   `   `  ����E  AStatWizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:StatWizard.PagesStatWizard.Pages  5      p lDotNetProjects.DataVisualization.Toolkit, Version=6.1.94.0, Culture=neutral, PublicKeyToken=79778c5f2eed289b�iclr-namespace:System.Windows.Controls.DataVisualization;assembly=DotNetProjects.DataVisualization.Toolkit)System.Windows.Controls.DataVisualization 5      �rclr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=DotNetProjects.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5      %    StatWizard.Pages.BySupplierPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:StatWizard.Pages     5      xDViclr-namespace:System.Windows.Controls.DataVisualization;assembly=DotNetProjects.DataVisualization.Toolkit     5      �DVCrclr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=DotNetProjects.DataVisualization.Toolkit     5        N� Title$  BySupplierPage��5      .��5      � 
�������.+�5   
   �� -   5         ��Name$ 
BackButton��5      $
��Back��6%   $
��Left=�64   $��21��6O   $��692,390,0,0q�6[   $	��Top=�6p   $��75��6�   6�   �� 5   
   -   5         ��Name$ SelectSupplierTextblock��5      $
��Left=�65   $��21��6P   $��	44,49,0,0q�6\   $
��Wrap=�6o   $��Please select a supplier:��6�   $	��Top=�6�   $	��183��6�   �� 5   
   -   5         ��Name$ SuppliersCombobox��5      $
��Left=�6.   $��21��6I   $��	44,75,0,0q�6U   $	��Top=�6h   $	��183��6�   �� 5   
   -   5        $ QueryButton��5      $��Query��6&   $
��Left=�66   $��21��6Q   $��
232,75,0,0q�6]   $	��Top=�6q   $��75��6�   6�   �� 5   
   -   5        $ SupplierCostTextblock��5      $
��Left=�63   $��40��6N   $��
312,75,0,0q�6Z   $
��Wrap=�6n   $	��Top=�6�   $	��455��6�   >  8System.Windows.Controls.DataVisualization.Charting.Chart  5   
   $��44,120,160,64q�6      Series. 5      C  =System.Windows.Controls.DataVisualization.Charting.LineSeries  -   5          Name$ 
Series2013��5      ?  9System.Windows.Controls.DataVisualization.Charting.Series   Title$
 2013��61   H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValueBinding 5      ��  �� Path$	 Key�	   DependentValueBinding	 5      �� $ Value�  5      -   5        $ 
Series2014��5      $
 2014��61    5      �� $	 Key�	 5      �� $ Value�5      5      �� 5   
   -   5        $ WeekTextBox��5      $
��Left=�6)   $��20��6D   $��325,393,0,0q�6P   $
��Wrap=�6e   $
��Week��6y   $	��Top=�6�   $��75��6�   �� 5    
   -	   5        $ WeeklyOrderCostTextblock��5       $
��Left=�66   $��21                    ��6Q   $��-48,241,0,0q�5!      $
��Wrap=�6+   $��Weekly order cost (£)��6?   $	��Top=�6\   $	��144��6t   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   z�5"      V� 5#      .~�5$      �� �� 5%      �� 5&       �� Angle$ -90.613Q�6&   T� 5'      5(      5*      5+      5,      