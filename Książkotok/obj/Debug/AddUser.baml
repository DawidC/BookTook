   M S B A M L   `   `   `  ����C  ?BookTook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BookTookBookTook  5   	       BookTook.AddUser   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:BookTook     5   	     � Title$  Dodaj użytkownika��5   	   $	��274��6#   $	��335��60   $	��335��6<   $	��274��6K   $	��335��6[   $	��274��6j    � Icon$ booktook logoznak.png��6z   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��124* �6   �� 5      $
��205* �6   .+�5   
   �� -   5         ��Name$ image��5      $��booktooktlo.jpg��6   $��2��68   $��UniformToFill=�6L   �� 5   
   -   5         ��Name$ 	labelimie��5      $��Imię��6#   $
��Left=�62   $��	26,34,0,0q�6M   $	��Top=�6`    J� RenderTransformOrigin$ 0.068,-0.436&�6x   $��26��6�   $��33��6�   
�������6�   �� 5   
   -   5        $ labelnazwisko��5      $��Nazwisko��6'   $
��Left=�6:   $��	26,65,0,0q�6U   $	��Top=�6h   $��26��6�   $��60��6�   
�������6�   �� 5   
   -   5        $ 
labelemail��5      $��Email��6$   $
��Left=�64   $��	26,96,0,0q�6O   $	��Top=�6b   $��26��6z   $��38��6�   
�������6�   �� 5   
   -   5        $ labeltelefon��5      $��Telefon��6&   $
��Left=�68   $��
26,127,0,0q�6S   $	��Top=�6g   $��26��6   $��48��6�   
�������6�   �� 5   
   -   5        $ labeltypkonta��5      $��	Typ konta��6'   $
��Left=�6;   $��
26,158,0,0q�6V   $	��Top=�6j   $��26��6�   $��62��6�   
�������6�   �� 5   
   -   5         ��Name$ buttondodaj��5      $��Dodaj��6&   $��Right=�66   $��	0,0,41,24q�6R   $��Bottom=�6e   $��75��6�   $��20��6�   $��1��6�   
����������	#FF5F4D83��6�   Z� �� 5   
   -   5         ��Name$ textBoximie��5      $��1��6'   $
��Left=�67   $��23��6R   $��0,38,0,0q�6^    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��164��6�   �� 5   
   -	   5        $ textBoxnazwisko��5      $��1��6+   $
��Left=�6;   $��23��6V   $��0,69,0,0q�6b   $
 Wrap=�6t   $	��Top=�6�   $	��164��6�   �� 5   
   -
   5        $ textBoxemail��5      $��1��6(   $
��Left=�68   $��23��6S   $��	0,100,0,0q�6_   $
 Wrap=�6r   $	��Top=�6�   $	��164��6�   �� 5   
   -   5        $ textBoxtelefon��5      $��1��6*   $
��Left=�6:   $��23��6U   $��	0,131,0,0q�6a   $
 Wrap=�6t   $	��Top=�6�   $	��164��6�   �� 5   
   -   5        	 ��Name$	 comboBoxtypkonta��5      $��1��6-   $
��Left=�6=   $��	0,162,0,0q�6X   $	��Top=�6k   $	��164��6�   $��22��6�   .@�5      �� $��Uczeń��6   $
��Left=�6+   $	��164��6F   �� 5      $��
Nauczyciel��6   $
��Left=�60   $	��164��6K   5      5      5       