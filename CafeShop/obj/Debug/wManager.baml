   M S B A M L   `   `   `  ����  CafeShop    CafeShop.wManager   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :xctk)http://schemas.xceed.com/wpf/xaml/toolkit     5   	   -   5          � Title$6  0Orange Cafe - Phần mềm quản lý quán cafe��5   	   $	��500��6:   $	��700��6G    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� .+�5	      o� 
�������$��25��6%   $
��Auto��61   .@�5
      m� $��_Tài khoản��6   .@�5      m� -   5        $��_Thông tin tài khoản��5      6=   �� 5      m� 5      -   5        $��_Đăng xuất��5      63   5      m� 5      -   5        $��	MenuAdmin��5   F   $��_Quản lý��6   5      m� 5      -   5        $��MenuThongKe��5   G   $��_Thống kê��6   5      5      ]� 5      
��� ���.+�5      �� $
��Left=�6   
���   �$��1q�6C   $	��440��6W   $	��340��6d   ._�5      �� .��5      �� -   5        $��	stacklist��5   %   5      5      5      �� 5      $��Right=�6   
���   �$��1q�6D   $	��440��6X   $	��340��6e   ._�5      �� .+�5      �� $	��130��6!   ._�5       � .+�5!   "   �� -   5        $��
cbCategory��5!   +   $
��Left=�6=   $��	117,2,0,0q�6X   $	��Top=�6k   $	��211��6�   $��25��6�   6�   �� 5"   "   -   5        $��cbFood��5"   +   $
��Left=�69   $��
154,30,0,0q�6T   $	��Top=�6h   $	��174��6�   $��25��6�   �� 5#   "   $��Chọn danh mục :��6(   $
��Left=�6B   $��10,2,0,0q�6]   $	��Top=�6o    J� RenderTransformOrigin$ -0.244,-0.504&�6�   $��25��6�   $	��102��6�   �� 5$   "   $'��!Chọn thức ăn, đồ uống :��6(   $
��Left=�6J   $��	10,30,0,0q�6e   $	��Top=�6x   $ -0.244,-0.504&�6�   $��25��6�   $	��139��6�   �� 5%   "   $��Số lượng :��6(   $
��Left=�6=   $��	84,60,0,0q�6X   $	��Top=�6k   $ -0.244,-0.504&�6�   $��25��6�   $��67��6�   �� 5&   "   -	   5        $��btnAdd��5&   )   $��Thêm vào hóa đơn��6N   
��� ���
��� ���$
��Left=�6�   $��	10,88,0,0q�6�   $	��Top=�6�   $	��318��6�   $��32��6�   $
��Bold"�6�   �� 5'   "   -
   5        $��	cbSoLuong��5'   +   $
��Left=�6<   $��
154,60,0,0q�6W   $	��Top=�6k   $	��174��6�   $��25��6�   .@�5(   &   �� $��1��63   6A   �� 5)   &   $��2��63   6A   �� 5*   &   $��3��63   6A   �� 5+   &   $��4��63   6A   �� 5,   &   $��5��63   6A   �� 5-   &   $��6��63   6A   �� 5.   &   $��7��63   6A   �� 5/   &   $��8��63   6A   �� 50   &   $��9��63   6A   �� 51   &   $��10��63   6B   52   #   54      55      &   System.Windows.Controls.DataGrid  56      -   5        $��dtgvBill��56   >   $	��200��6#   $
��10,0q�60      AutoGenerateColumns . 58      �� 59      $	��100��6!   ._�5:      � .+�5;   "   �� $��Giảm giá (%) :��6(   $
��Left=�6A   $��	10,10,0,0q�6\   $	��Top=�6o   $ -0.914,-0.326&�6�   $��93��6�   $��27��6�   
��� ���6�   �� 5<   "   $��Tổng tiền :��6(   
��� ���$
��Left=�6R   $��	10,42,0,0q�6m   $	��Top=�6�   $��93��6�   �� 5=   "   -   5        $��txtTongTien��5=   *   $
��Left=�6=   $��26��6X   $��
108,42,0,0q�6d    �� TextWrapping$
 Wrap=�6x   $	��0.0��6�   $	��Top=�6�   $	��220��6�   �� 5>   "   -   5        $'��!Thanh toán và xuất hóa đơn��5>   @   
��� ���
��� ���$
��Left=�6�   $��	10,73,0,0q�6�   $	��Top=�6�   $	��318��6�   $��27��6�   $
��Bold"�6�   �� 5?   "   -   5        $��	cbGiamGia��5?   +   $
��Left=�6<   $��
108,10,0,0q�6W   $	��Top=�6k   $	��220��6�   $��27��6�    �� SelectedIndex$ -1��6�   .@�5@   &   �� $��0��63   6A   �� 5A   &   $��10��63   6B   �� 5B   &   $��20��63   6B   �� 5C   &   $��30��63   6B   �� 5D   &   $��40��63   6B   �� 5E   &   $��50��63   6B   �� 5F   &   $��60��63   6B   �� 5G   &   $��70��63   6B   �� 5H   &   $��80��63   6B   �� 5I   &   $��90��63   6B   �� 5J   &   $	��100��63   6C   5K   #   5M      5N      5O      5P      5Q      5S      5U      5V      