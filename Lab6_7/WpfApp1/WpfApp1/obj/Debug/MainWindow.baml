   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1000��6,   $	��600��6<   $
��1000��6I   ���#27273d J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ local:CustomCommands.Save��5      6X     5   
   -   5        $ local:CustomCommands.Open��5      6X     5   
   -   5        $" local:CustomCommands.NewFile��5      6Z     5   
   -   5        $! local:CustomCommands.SaveAs��5      6]     5   
   -   5        $  local:CustomCommands.Close��5      6Z     5   
   -   5        $ local:CustomCommands.Help��5      6X     5   
   -   5        $  local:CustomCommands.About��5      6Z     5   
   -   5        $ local:CustomCommands.Bold��5      6X   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $	��19* �6   6+   .+�5   
   ]� $��0��6   .+�5      o� $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� $	��New��6    m� Command$" local:CustomCommands.NewFile��6,   6U   m� 5      $
��Open��6   $ local:CustomCommands.Open��6-   6S   m� 5      $
��Save��6   $ local:CustomCommands.Save��6-   6S   m� 5       $��Save As��6   $! local:CustomCommands.SaveAs��60   6X   m� 5!      $��Close��6   $  local:CustomCommands.Close��6.   6U   5"      m� 5#      $
��Edit��6   .@�5$      m� $	��Cut��6   $	 Cut��6,   6<   m� 5%      $
��Copy��6   $
 Copy��6-   6>   m� 5&      $��Paste��6   $ Paste��6.   6@   5'      m� 5(      $��Other��6   .@�5)      m� $
��Help��6   $ local:CustomCommands.Help��6-   6S   m� 5*      $��About��6   $  local:CustomCommands.About��6.   6U   5+      5,      5-      ]� 5.   
   $��1��6   .+�5/      c� $	��Top=�6   .@�50      ��  � ToolTip$	 Cut��6   $	��Cut��6'   .��51      �� -	   5         ��Name$	 Cut��51      6+   52      �� 53      $
 Copy��6   $
��Copy��6(   .��54      �� -
   5        $
 Copy��54      6,   55      �� 56      $ Paste��6   $��Paste��6)   .��57      �� -   5        $ Paste��57      6-   58      �� 59      $
 Bold��6   $��local:CustomCommands.Bold��6(   .��5:      �� -   5        $
 Bold��5:      6,   5;      �� 5<      -   5         ��Name$ Bold_Button��5<   F   $ Italic��6   .��5=      �� -   5        $ Italic��5=      6.   5>      �� 5?      -   5        $ Alight Left��5?      .��5@      �� -   5        $ Alight_Left��5@      63   5A      �� 5B      -   5        $ Alight Center��5B      .��5C      �� -   5        $ Alight_Center��5C      65   5D      �� 5E      -   5        $ Alight Right��5E      .��5F      �� -   5        $ Alight_Right��5F      65   5G      5H      5I      �� 5J   
   -   5         ��Name$ RichTextEditor��5J      $��2��6.   $��10q�6;   $��16(�6G   ���#3a3a52
�������5K      5L      5M      