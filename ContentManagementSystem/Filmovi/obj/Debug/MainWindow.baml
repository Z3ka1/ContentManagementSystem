   M S B A M L   `   `   `  ����B  >Filmovi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FilmoviFilmovi  5   	       Filmovi.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Filmovi     5   	   -   5          � Title$  Filmovi komedije��5   	   $	��450��6"   $	��800��6/    � WindowStyle$
 None=�6;    � AllowsTransparency . 
������  � SizeToContent$ WidthAndHeight=�5	   :   .��5
      �� $	��450��6   $	��800��6   .+�5   
   F� -   5        $��UIPath��5   8   
������ $��1��6$   $��Center=�6F   $	��450��6c    �� Stretch$
 Fill=�6p   $	��Top=�6   ��5      �� 5       �� ImageSource$ slike/background.jpg��6   ��5      B� 5      .��5      E�  E� 
StartPoint$
 50,0&�6!   .��5      ��  �� Point$
 0,50&�6%    �� Size$ 50,50��62   �� 5      	 �� Point$	 0,450&�6&   �� 5      $ 50,500&�6%   $ 50,50��64   �� 5      $	 750,500&�6&   �� 5      $ 800,450&�6%   $ 50,50��65   �� 5      $	 800,50&�6&   �� 5      $ 750,0&�6%   $ 50,50��63   �� 5      $
	 50,0&�6&   5      5      5      �� 5   
   -   5        
 ��Name$
 btnIzlaz��5      $��50��6P   $��50��6[    �� Right$ 50��6g   
 �� Top$ 40��6y   ��6:   Z� .��5       �� $��slike/exit.png��6   6/   5!      ]� 5"   
    �� Left$ 50��6   $ 25��6%   $	��400��65   $	��700��6B   .+�5#      �� .+�5$      �� $��Prijava na sistem��6   $��50(�64   
�������$��Center=�6U   6t   �� 5%      $��Korisnicko ime��6   $��25(�61   $��0 20 0 0q�6?   
�������$��Center=�6d   �� 5&      -   5         ��Name$ tbKorisnickoIme��5&      $	��250��63   $��25��6?   $��20(�6K   6[   �� 5'      $��Lozinka��6   $��25(�6*   $��0 20 0 0q�68   
�������$��Center=�6]   G� 5(      -   5         G�Name$ 
pwbLozinka��5(      $	��250��62   $��25��6>   $��20(�6J   6Z   �� 5)      -   5        $
 
btnPrijava��5)      $��
Prijavi se��6F   $��18(�6[   $	��175��6i   $��40��6u   $��0 50 0 0q�6�   6�   5*      5+      5-      5.      