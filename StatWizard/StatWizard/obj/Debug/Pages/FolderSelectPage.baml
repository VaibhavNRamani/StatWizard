   M S B A M L   `   `   `  ����E  AStatWizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:StatWizard.PagesStatWizard.Pages  5      '    !StatWizard.Pages.FolderSelectPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:StatWizard.Pages     5        N� Title$  FolderSelectPage��5	      .��5      � 
�������.+�5   
   �� -   5         ��Name$ ContinueButton��5      $��Continue��6)   $
��Left=�6<   $��21��6W   $��692,390,0,0q�6c   $	��Top=�6x   $��75��6�   6�   �� 5   
   -   5         ��Name$ SelectFolderTextBlock��5      $
��Left=�63   $��21��6N   $��	23,51,0,0q�6Z   $
��Wrap=�6m   $@��:Please select a folder containing the .csv files to query:��6�   $	��Top=�6�   $	��292��6�   �� 5   
   -   5        $ SelectFileTextBlock��5      $
��Left=�61   $��21��6L   $��	23,91,0,0q�6X   $
��Wrap=�6k   $;��5Please select a .csv file containing the store codes:��6   $	��Top=�6�   $	��292��6�   �� 5   
   -   5        $ FolderSelectButton��5      $��Select��6-   $
��Left=�6>   $��21��6Y   $��
692,51,0,0q�6e   $	��Top=�6y   $��75��6�   6�   �� 5   
   -   5         ��Name$ FolderDirectoryTextbox��5      $
��Left=�62   $��21��6M   $��
320,51,0,0q�6Y    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��367��6�   �� 5   
   -   5        $ FileSelectButton��5      $��Select��6+   $
��Left=�6<   $��21��6W   $��
692,91,0,0q�6c   $	��Top=�6w   $��75��6�   6�   �� 5   
   -   5        $ FileDirectoryTextbox��5      $
��Left=�60   $��21��6K   $��
320,91,0,0q�6W   $
 Wrap=�6k   $	��Top=�6   $	��367��6�   � 5   
   -   5         �Name$ LoadingProgressBar��5      $
��Left=�62   $��21��6M   $��
23,390,0,0q�6Y   $	��Top=�6m   $	��664��6�    � IsIndeterminate . $y�Hidden=�6�   5      5      