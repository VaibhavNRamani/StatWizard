   M S B A M L   `   `   `  ����E  AStatWizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:StatWizard.PagesStatWizard.Pages  5      p lDotNetProjects.DataVisualization.Toolkit, Version=6.1.94.0, Culture=neutral, PublicKeyToken=79778c5f2eed289b�rclr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=DotNetProjects.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5      )    #StatWizard.Pages.BySupplierTypePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:StatWizard.Pages     5      �DVCrclr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=DotNetProjects.DataVisualization.Toolkit     5        N� Title$  BySupplierTypePage��5
      .��5      � 
�������.+�5   
   �� -   5         ��Name$ 
BackButton��5      $
��Back��6%   $
��Left=�64   $��21��6O   $��692,390,0,0q�6[   $	��Top=�6p   $��75��6�   6�   �� 5   
   -   5         ��Name$ SelectSupplierTextBlock��5      $
��Left=�65   $��21��6P   $��	43,51,0,0q�6\   $
��Wrap=�6o   $$��Please select a supplier type:��6�   $	��Top=�6�   $	��183��6�   �� 5   
   -   5         ��Name$ SupplierTypesComboBox��5      $
��Left=�62   $��21��6M   $��	43,77,0,0q�6Y   $	��Top=�6l   $	��183��6�   �� 5   
   -   5        $$ QuerySupplierTypeCostTextblock��5      $��Query��69   $
��Left=�6I   $��21��6d   $��
231,77,0,0q�6p   $	��Top=�6�   $��75��6�   6�   �� 5   
   -   5        $$ SupplierTypeTotalCostTextblock��5      $
��Left=�6<   $��42��6W   $��
311,77,0,0q�6c   $
��Wrap=�6w   $	��Top=�6�   $	��456��6�   �� 5   
   -   5        $ SelectDateTextBlock��5      $
��Left=�61   $��21��6L   $��
43,124,0,0q�6X   $
��Wrap=�6l   $��Please select a date: ��6�   $	��Top=�6�   $	��183��6�   �� 5   
   -   5        $ WeekComboBox��5      $
��Left=�6)   $��21��6D   $��
43,150,0,0q�6P   $	��Top=�6d   $��91��6|   �� 5   
   -   5        $ YearComboBox��5      $
��Left=�6)   $��21��6D   $��134,150,0,0q�6P   $	��Top=�6e   $��92��6}   �� 5   
   -	   5        $ QueryByWeekButton��5      $��Query��6,   $
��Left=�6<   $��21��6W   $��231,150,0,0q�6c   $	��Top=�6x   $��75��6�   6�   �� 5   
   -
   5        $ CostByWeekTextblock��5      $
��Left=�61   $��42��6L   $��311,150,0,0q�6X   $
��Wrap=�6m   $	��Top=�6�   $	��456��6�   >  8System.Windows.Controls.DataVisualization.Charting.Chart  5   
   $��43,193,411,39q�6      Series. 5      B  <System.Windows.Controls.DataVisualization.Charting.PieSeries  -   5          Name$ SupplierTypeSeries��5      ?  9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Sales��68   H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValueBinding 5      ��  �� Path$	 Key�	   DependentValueBinding	 5      �� $ Value�5      �� 5   
   -   5        $  PercentageOfCostsTextBlocl��5      $
��Left=�68   $��30��6S   $��132,201,0,0q�6_   $
��Wrap=�6t   $	��Top=�6�   $	��168��6�   �� 6�   $&� % of total cost by supplier type��6�   �� 6�   $�.��6�   �� 6�   �� 6�   $�(hover over pie to see ��6�   �� 6  
 � Language$
 en-gb�6  $�%��60  �� 6;  $� share)��6?  �� 6P  �� 6\  6c  5      5      