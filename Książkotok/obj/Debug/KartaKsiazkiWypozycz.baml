   M S B A M L   `   `   `  ����C  ?BookTook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BookTookBookTook  5   	   #    BookTook.KartaKsiazkiWypozycz   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:BookTook     5   	     � Title$  	Wypożycz��5   	   $	��359��6    � Icon$ booktook logoznak.png��6&   $	��247��6C   $	��359��6P   $	��359��6_   $	��247��6n   $	��247��6~   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��40* �6   �� 5      $
��147* �6   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $��booktooktlo.jpg��6:   $��2��6S   $��UniformToFill=�6d   $	��359��6|   �� 5   
   -   5         ��Name$ button_wypozycz��5      $��	Wypożycz��6*   $��Right=�6=   $��	0,0,16,16q�6Y   $��Bottom=�6l   $��75��6�   $��1��6�   $��20��6�   ���	#FFA68294
���������6�   Z� 6�   �� 5   
   -   5         ��Name$ listView��5      $
��Left=�6%   $	��110��6@   $��10,7,0,0q�6M   $	��Top=�6_   $	��326��6w   $��1��6�    �� View 5      �� 5      .P�5      �� $��Id��6%    �� DisplayMemberBinding 62   �� *Id+�� 5      $��Imię��6%    64   �� *Imie+�� 5      $��Nazwisko��6%    68   �� *
Nazwisko+5      5      � 5   
   .+�5      �� -   5         ��Name$ textBox��5      $
��Left=�6C   $��23��6^   $��	10,17,0,0q�6j   	 �� TextWrapping$
	 Wrap=�6}   $��Szukaj��6�   $	��Top=�6�   $	��326��6�   6�   �� 5      -   5        $ button��5      $��	0,17,15,0q�6%   $	��Top=�68   $��21��6P   $��25��6s   $��Right=�6~   ��6\   Z� ��6�   Z� .��5      �� -   5        $ image1��5      $��21��6(   $��18��64   $��lupa.png��6?   $��Right=�6Q   $	��Top=�6m   5      5!      5"      5#      