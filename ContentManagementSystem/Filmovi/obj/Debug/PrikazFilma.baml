   M S B A M L   `   `   `  ����B  >Filmovi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FilmoviFilmovi  5   	       Filmovi.PrikazFilma   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Filmovi     5   	   -   5          � Title$  PrikazFilma��5   	   $	��450��6   $	��800��6*    � WindowStyle$
 None=�66    � AllowsTransparency . 
������  � SizeToContent$ WidthAndHeight=�5	   T   .��5      �� $	��450��6   $	��800��6   .+�5   
   F� -   5        $��UIPath��5   8   
������ $��1��6$   $��Center=�6F   $	��450��6c    �� Stretch$
 Fill=�6p   $	��Top=�6   ��5      �� 5       �� ImageSource$ slike/background.jpg��6   ��5      B� 5      .��5      E�  E� 
StartPoint$
 50,0&�6!   .��5      ��  �� Point$
 0,50&�6%    �� Size$ 50,50��62   �� 5      	 �� Point$	 0,450&�6&   �� 5      $ 50,500&�6%   $ 50,50��64   �� 5      $	 750,500&�6&   �� 5      $ 800,450&�6%   $ 50,50��65   �� 5      $	 800,50&�6&   �� 5      $ 750,0&�6%   $ 50,50��63   �� 5      $
	 50,0&�6&   5      5      5      �� 5    
   -   5        
 ��Name$
 btnIzlaz��5       $��50��6Q   $��50��6\    �� Right$ 50��6h   
 �� Top$ 40��6z   ��6;   Z� .��5!      �� $��slike/exit.png��6   6/   5"      � 5$   
    �� Left$ 50��6   $ 25��6    $	��400��60   $	��700��6=    � RowDefinitions 5%      �� 5&      6"   �� 5'      6"   �� 5(      6"   �� 5)      6"    � ColumnDefinitions 5,      �� 5-      6%   �� 5.      6%   .+�51      �� $��Informacije o filmu��6   
�������$��40(�6E   $��Center=�6S   $��Center=�6p   6�   �� 53      $��1��6   $��Center=�6&   .+�54      �� $��Naziv filma��6   
�������$��20(�6A   $
��10 0q�6O   6_   �� 55      -   5        $��tbNaziv��55      $��20(�6)    �� 
IsReadOnly . $
��15 0q�6I   
�������6p   56      �� 58      $��2��6   $��Center=�6&   .+�59      �� $��Trajanje filma��6   
�������$��20(�6D   $
��10 0q�6R   6b   �� 5:      -   5        $��
tbTrajanje��5:      $��20(�6,    . $
��15 0q�6L   
�������6s   5;      �� 5=      $��3��6   $��Center=�6&   .+�5>      �� $��Datum dodavanja��6   
�������$��20(�6E   $
��10 0q�6S   6c   �� 5?      -   5        $��tbDatum��5?      $��20(�6)    . $
��15 0q�6I   
�������6p   5@      �� 5B      $��1��6   $��2��6)   $��Bottom=�6:   $��	10 0 10 0q�6U   .+�5C      �� $
��Opis��6   
�������$��20(�6:   $
��10 0q�6H   6X   �� 5D      -   5        $��rtbOpis��5D      $	��125��6-   
������� . 6e   5E      �� 5G      $��1��6   $��2��6%   $��2��62   $��10q�6C   $��2q�6O   
���  ��._�5H      �� -   5        $��imgSlika��5H      6*   5I      5K      5M      5N      