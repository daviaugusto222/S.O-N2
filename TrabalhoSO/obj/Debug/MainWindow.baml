   M S B A M L   `   `   `  ����E  ATrabalhoSO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TrabalhoSO
TrabalhoSO  5   	   A%clr-namespace:TrabalhoSO.ChartControlTrabalhoSO.ChartControl  5   	       TrabalhoSO.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:TrabalhoSO     5   	   7Chart%clr-namespace:TrabalhoSO.ChartControl     5   	     � Title$  S.O-N2��5	   	   $	��800��6   $
��1100��6%   .��5      �  J� RenderTransformOrigin$ 0.664,0.323&�6    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      .+�5   
   �� $��2��6   $��Entrada��6'   $
��Left=�68   $	��178��6S   $��	10,10,0,0q�6`   $	��Top=�6s   $	��297��6�   .��5      � $
��Left=�6   $	��157��6.   $��0,10,-2.2,0q�6;   $	��Top=�6P   $	��287��6h   .+�5      �� $��Q1��6   $
��Left=�6%   $��	25,10,0,0q�6@   $	��Top=�6S   �� 5      -   5         ��Name$ Q2text��5      $
��Left=�6*   $��23��6E   $��
117,38,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��120��6�   �� 5      -   5        $ Q1text��5      $
��Left=�6*   $��23��6E   $��
117,10,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6y   $	��120��6�   �� 5      -   5        $ ZerarBitRtext��5      $
��Left=�61   $��23��6L   $��
117,66,0,0q�6X   $
 Wrap=�6l   $	��Top=�6�   $	��120��6�   �� 5      $��Q2��6   $
��Left=�6%   $��	25,38,0,0q�6@   $	��Top=�6S   �� 5      $��
Zerar BitR��6   $
��Left=�6-   $��	25,63,0,0q�6H   $	��Top=�6[   �� 5      -   5         ��Name$ btnOpenFile��5      $��Buscar Arquivo��6H   $
��Left=�6a   $��
74,107,0,0q�6|   $	��Top=�6�   $	��109��6�   5      5      �� 5   
   $��2��6   $��Tabela��6'   $
��Left=�67   $	��363��6R   $��
325,10,0,0q�6_   $	��Top=�6s   $	��759��6�   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ tabela��5      $
��Left=�6'   $	��749��6B      
IsReadOnly . $��0,10,-2.6,2.8q�6`      MinColumnWidth$ 80Q�6w   5      �� 5   
   $��2��6   $��Gráfico��6'   $
��Left=�68   $	��376��6S   $��
10,384,0,0q�6`   $	��Top=�6t   $
��1074��6�   .��5!      (   "TrabalhoSO.ChartControl.BasicChart  -   5        	  Name$	 MyChart��5!      $	��350��60   $
��1000��6=   
   DataCollectionName$
 MyData��5"         DisplayMemberLabels$ 	Frequency��5#         DisplayMemberValues$ Value��5$         
SkipLabels$ 1��5%         StartSkipAt$ 0��5&         ShowGraphPoints .    
ChartTitle$. (Algoritmos de Substituição de Páginas��5(         YLabel$ Quantidade de Acertos��6H      XLabel$ Q. de Frames��5)         YMax$ 1Q�5*         YMin$ 0Q�5+         DoubleToString$ N0��5,         XMin$ 0Q�5-         XMax$ 0Q�6   50      53      56      57      