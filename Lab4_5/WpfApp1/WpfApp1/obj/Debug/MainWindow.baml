   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��850��6   $
��1040��6)   $	��850��66   $
��1040��6F   ���#2A323C
�������.��5	      �  � RowDefinitions 5
   
   �� 5      $
��408* �6   6,   �� 5      $	��41* �6   6+   �� 5      $	��58* �6   6+   �� 5      $	��87* �6   6+   �� 5      $	��58* �6   6+   �� 5      $	��49* �6   6+   �� 5      $	��58* �6   6+    � ColumnDefinitions 5   
   �� 5      $
��193* �6   6.   �� 5      $	��86* �6   �� 5      $	��82* �6   6-   �� 5      $
��253* �6   �� 5      $
��418* �6   6.   .+�5   
   �� $��2��6   .+�5      �� $��16(�6   $��Center=�6"   
�������.��6R   Wybierz pizze6a   �� 5      -   5         ��Name$ 
pizzasList��5      $��16(�6+   .@�5      �� $��5q�6   $��16(�6*   .��68   
Hawajska6B   �� 5      $��5q�6   $��16(�6*   .��68   Wegetariańska6G   �� 5      $��5q�6   $��16(�6*   .��68   	Al capone6C   �� 5       $��5q�6   $��16(�6*   .��68   	Americana6C   �� 5!      $��5q�6   $��16(�6*   .��68   
Broccoli6B   5"      �� 5#      -   5         ��Name$ pizzaDisplay��5#      .+�5$      �� -   5         ��Name$ 
pizzaImage��5$      $��80��6,   $��80��67   $��5q�6C   6P   �� 5%      -   5         ��Name$ 	pizzaName��5%      $��5q�6+   68   �� 5&      -   5         ��Name$ 	pizzaDesc��5&      $��5q�6/   
���   �$��WrapWithOverflow=�6M   6o   5'      5(      �� 5)   
   $��2��6   $��2��6%   .+�5*      �� $��1��6   $��Wybierz Dodatki��6'   $��18(�6@   .��5+      �� .+�5,      �� -   5         ��Name$ topping1��5,      $��5q�61   $��16(�6<   
�������.��6�   Ciasto grube6�   �� 5-      -   5        $ topping2��5-      $��5q�61   $��16(�6<   
�������.��6�   Ananas6�   �� 5.      -   5        $ topping3��5.      $��5q�61   $��16(�6<   
�������.��6�   Bekon6�   �� 5/      -	   5        $ topping4��5/      $��5q�61   $��16(�6<   
�������.��6�   
Brokuły6�   �� 50      -
   5        $ topping5��50      $��5q�61   $��16(�6<   
�������.��6�   	Kukurydza6�   �� 51      -   5        $ topping6��51      $��5q�61   $��16(�6<   
�������.��6�   Kurczak grilowany6�   �� 52      -   5        $ topping7��52      $��5q�61   $��16(�6<   
�������.��6�   Pomidor suszony6�   53      54      55      �� 56   
   $��4��6   .+�57      �� $��Rozmiar pizzy
��6   $��18(�68   .��58      �� .+�59      	� -   5        	 	�Name$	 size1��59   "   $��5q�61   $��16(�6<   
�������.��6}   Mały6�   	� 5:      -   5        $	 size2��5:   "   $��5q�61   $��16(�6<   
�������.��6}   	Średni6�   	� 5;      -   5        $	 size3��5;   "   $��5q�61   $��16(�6<   
�������.��6}   Duży6�   5<      5=      �� 5>      $��5q�6   $��Center=�6   $��16(�6<   
�������.��6]   Poziom ostrości sosu6s   �� 5?      -   5        $ 
SauseLabel��5?      $��5q�6(   $��Center=�63   $��16(�6P   
�������.��6q   Ostrość sosu6   �� 5@      -   5        
 ��Name$
 Sause��5@      $��5q�6$    � Minimum$ 0Q�6/    � Maximum$	 100Q�6;    � Value$ 0Q�6I    �� IsSnapToTickEnabled . 6�   �� 5A      $��5q�6   $��16(�6   $��Center=�6-   
�������.��6]   Uwagi6d   �� 5B      -   5         ��Name$ CommentsTyped��5B      $��5q�6-    �� TextWrapping$
 Wrap=�68   $��14(�6L   $��70��6Z   ���#2A323C
�������6�   5C      �� 5D   
   -   5        $ FreeDeliveryInformation��5D      $��1��61   $��3��6>   $��Center=�6R   $��Center=�6o   $��16(�6�   $��2��6�   $��
47,6,322,6q�6�   
�������.��6�   64Brakująca wartość zamówienia do darmowej dostawy6  � 5E   
   -   5         �Name$ FreeDelivery��5E      $��5q�6,   $��2��67   $��5��6D   $ 0Q�6X   $ 30Q�6d   ���#2A323C6�   �� 5F   
   -   5        $ Ordered��5F      $��3��6#   $��5q�60   $��5��6;   $��16(�6O   $
 Wrap=�6]    �� 
IsReadOnly . ���#2A323C
�������.��6�   Wybrałeś:6�   �� 5G   
   -   5        $ Wynik��5G      $��4��6   $��16(�6,   $��5��6:   
�������.��6a   Koszt:6i   �� 5H   
   -   5        $ Comments��5H      $��5��6#   $��16(�60   $��5��6>   $��2��6R   $��Lucida Calligraphy)�6c   
�������.��6�   Uwagi:6�   � 5I   
   $��6��6   $��5��6    5J      �� 5K      6%   �� 5L      6%   �� 5M      6%   �� 5N      6%   .+�5P      �� -   5        $��1��5P      ���#2A323C.��5Q      �� .+�5R      �� 
�������.��6/   Anuluj67   �� 5S      -   5        $ Cancel��5S      $��31��6,   6:   5T      5U      �� 5V      -   5        $��2��5V      ���#2A323C.��5W      �� .+�5X      �� 
�������.��6/   Zamów66   �� 5Y      -   5        $ Order��5Y      $��31��6+   69   5Z      5[      5\      5]      5^      