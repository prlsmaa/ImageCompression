   M S B A M L   `   `   `  ����K  GImageCompression, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ImageCompressionImageCompression  5      b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5          ImageCompression.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      0localclr-namespace:ImageCompression     5      ]themeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5        �� 	Resources  5         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  TextBox.Static.Background �� Color  ComboBoxEditableTextBox �� 
TargetType �� 
TargetType ��Name  ComboBox.Static.Background	 �� EndPoint
 �� 
StartPoint � Color � Offset  ComboBox.Static.Border  ComboBox.Static.Glyph ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background *	 &ComboBox.Static.Editable.Button.Border !
 ComboBox.MouseOver.Background  ComboBox.MouseOver.Border  ComboBox.MouseOver.Glyph * &ComboBox.MouseOver.Editable.Background & "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Background  ComboBox.Pressed.Border  ComboBox.Pressed.Glyph ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border   ComboBox.Disabled.Background  ComboBox.Disabled.Border  ComboBox.Disabled.Glyph ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBoxToggleButton ��Name J� OpacityMask F�Name �� Triggers ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value �� 
TargetName P� Property P� Value   ComboBoxEditableTemplate �Name � ColumnDefinitions �Name � AllowsTransparency5  /Microsoft.Windows.Themes.SystemDropShadowChrome  Name   Color �� MaxDropDownHeight  �� ElementName! �� ClearTypeHint" ��Name# ��Name$ ��Name-  'System.Windows.Input.KeyboardNavigation%   DirectionalNavigation& d�Name' d� 	IsChecked( �� Mode) J� RenderTransformOrigin* �� AngleY+ T� Y, ��Name- �� SelectionBrush. �� 
IsReadOnly/ P� 
SourceName0 ]� 
Conditions1 �� Property ! ComboBoxTemplate2 K� IsItemsHost " CustomComboBoxStyle3 �� Triggers��%�(  &	        &	 �     &	 �     &	 	    &	 �    &	 �    &	 �    &	     &	 /    &		 T    &	
 y    &	     &	 8    &	 [    &	 ~    &	 �    &	 =    &	 `    &	 �    &	     &	 B    &	 e    &	 �    &	 $    &	 G    &	 j    &	 �    &	 �    &	 �    &	 �    &	 	    &	 @	    7  7  7  7 	 7  7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	  �    7  7  &	! o"    &	" ,$    7   7 ! 7   �� 5	   
   .�5
      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E    . $��1��6�   5      5      5      �� 5   
   $ 	#FFFFFFFF��6<   �� 5   
   " ��60   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@J�	AllowDrop . 6*   �� 5       � ��$ 0��6)   �� 5       � ��$ 0��6*   �� 5       �@�FocusVisualStyle 61   Z� �� 5       �@��PanningMode$ VerticalFirst=�69   �� 5       �@��IsFlicksEnabled .  67   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ PART_ContentHost��6'   ���	#FF333333|�.  $��Hidden=�6j   $��Hidden=�6�   ���	#FF3333336�   5      5!      5"      �� 5#   
   $		 0,1&�6A   $	
 0,0&�6P   .��5$      � $ 	#FFF0F0F0��6   $	 0.0Q�6-   � 5%      $ 	#FFE5E5E5��6   $	 1.0Q�6-   5&      �� 5'   
   $ 	#FFACACAC��69   �� 5(   
   $ 	#FF606060��68   �� 5)   
   $ #FFFFFF��6F   �� 5*   
   $ 	#FFABADB3��6B   �� 5+   
   $ Transparent��6M   �� 5,   
   $ Transparent��6I   �� 5-   
   $		 0,1&�6D   $	
 0,0&�6S   .��5.      � $ 	#FFECF4FC��6   $	 0.0Q�6-   � 5/      $ 	#FFDCECFC��6   $	 1.0Q�6-   50      �� 51   
   $ 	#FF7EB4EA��6<   �� 52   
   $ 	#FF000000��6;   �� 53   
   $ 	#FFFFFFFF��6I   �� 54   
   $ 	#FF7EB4EA��6E   �� 55   
   $		 0,1&�6T   $	
 0,0&�6c   .��56      � $ 	#FFEBF4FC��6   $	 0.0Q�6-   � 57      $ 	#FFDCECFC��6   $	 1.0Q�6-   58      �� 59   
   $ 	#FF7EB4EA��6L   �� 5:   
   $		 0,1&�6B   $	
 0,0&�6Q   .��5;      � $ 	#FFDAECFC��6   $	 0.0Q�6-   � 5<      $ 	#FFC4E0FC��6   $	 1.0Q�6-   5=      �� 5>   
   $ 	#FF569DE5��6:   �� 5?   
   $ 	#FF000000��69   �� 5@   
   $ 	#FFFFFFFF��6G   �� 5A   
   $ 	#FF569DE5��6C   �� 5B   
   $		 0,1&�6R   $	
 0,0&�6a   .��5C      � $ 	#FFDAEBFC��6   $	 0.0Q�6-   � 5D      $ 	#FFC4E0FC��6   $	 1.0Q�6-   5E      �� 5F   
   $ 	#FF569DE5��6J   �� 5G   
   $ 	#FFF0F0F0��6?   �� 5H   
   $ 	#FFD9D9D9��6;   �� 5I   
   $ 	#FFBFBFBF��6:   �� 5J   
   $ 	#FFFFFFFF��6H   �� 5K   
   $ 	#FFBFBFBF��6D   �� 5L   
   $ Transparent��6O   �� 5M   
   $ Transparent��6K   �� 5N   
   " d�6-   .�5O      ��  �@�OverridesDefaultStyle . 66   �� 5P       � �� .  6*   �� 5Q       � |� .  6*   �� 5R       �@��	ClickMode$ Press=�6*   �� 5S       � �� 5T      �� 5U      " d�6&   .R�5V      �� $ templateRoot��6!   ���	#FF333333#��z��6N    . ��6�   Z�  6�   Z� ._�5W      �� $ splitBorder��6%   
������ $��1q�6T   $��Right=�6h   $��0q�6�    . #��� r�6�   ._�5X   "   F� $ arrow��6'   F����        ���( ��( јaQ     јaQ P����̰( � �    P����        ���	#FF8F8F8F$��Center=�6�   $��0q�6�   $��Center=�6�   5Y      5Z       5[      ^� 5\       5]   "   �� 5^   &    60   �� *
IsEditable+ �� " �� true6�   �� 5_   &    60   �� *IsMouseOver+ �� *Self+	 false6v   �� 5`   &    60   �� *	IsPressed+ �� *Self+	 false6t   �� 5a   &    60   �� *	IsEnabled+ �� *Self+ true6t   .0�5c   "   �� $ templateRoot��6?   8    � ��6Y   �� 5d   "   $ templateRoot��6@   8   � ��6Z   �� 5e   "   $ splitBorder��6?   8   � ��6X   �� 5f   "   $ splitBorder��6@   8   � ��6Y   5g      P� 5h       �@J�IsMouseOver . . �5i   "   �� $ arrow��69   8   � ��6L   5j      ^� 5k       5l   "   �� 5m   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5n   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5p   "   �� $ templateRoot��6?   8   � ��6Y   �� 5q   "   $ templateRoot��6@   8   � ��6Z   5r      ^� 5s       5t   "   �� 5u   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5v   &    60   �� *
IsEditable+ �� " �� true6�   .0�5x   "   �� $ templateRoot��6?   8   � ��6Y   �� 5y   "   $ templateRoot��6@   8   � ��6Z   �� 5z   "   $ splitBorder��6?   8 	  � ��6X   �� 5{   "   $ splitBorder��6@   8 
  � ��6Y   5|      P� 5}       � �� . . �5~   "   �� $ arrow��69   8   � ��6L   5      ^� 5�       5�   "   �� 5�   &    60   �� *	IsPressed+ �� *Self+ true6t   �� 5�   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsPressed+ �� *Self+ true6t   �� 5�   &    60   �� *
IsEditable+ �� " �� true6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   �� 5�   "   $ splitBorder��6?   8   � ��6X   �� 5�   "   $ splitBorder��6@   8   � ��6Y   5�      P� 5�       � {� .  . �5�   "   �� $ arrow��69   8   � ��6L   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5�   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5�   &    60   �� *
IsEditable+ �� " �� true6�   .0�5�   "   �� $ templateRoot��6?   8   � ��6Y   �� 5�   "   $ templateRoot��6@   8   � ��6Z   �� 5�   "   $ splitBorder��6?   8   � ��6X   �� 5�   "   $ splitBorder��6@   8   � ��6Y   5�      5�      5�      5�      �� 5�   
   " ��6;   .R�5�      � $ templateRoot��6    . ���	#FF333333 �	#FF333333$��0,0,2,0q�6s    5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   $��Bottom=�6�   #��� .�6�   ��6Z   �� *IsDropDownOpen+ �� *TemplatedParent+.��5�        $ shadow��63   $ Transparent��6C   #��z 6�   ��6W   �� *ActualWidth+$  templateRoot��._�5�      �� $ dropDownBorder��6!   #��� ��69   #��� ��6   $��1q�6�   ._�5�      �� $ DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $! Enabled=�65   .+�5�   &   �� $" canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $# 
opaqueRect��64   ��6H   �� *
Background+$  dropDownBorder����6�   �� *ActualHeight+$  dropDownBorder����6�   �� *ActualWidth+$  dropDownBorder��5�   '   �� 5�   &   $$ ItemsPresenter��65   $% 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $& toggleButton��6   #��z��65   #��z��6_   #��z��6�   $��2��6�   8��  ���	#FF333333' 6�   �� *IsDropDownOpen+$( TwoWay=� �� *TemplatedParent+6d  �� 5�      $ border��6   ���	#FF333333$��1,1,0,1q�6@   ���	#FF333333$) 0.5,0.5&�6i   $��2��6�   $
��Left=�6�   $	��208��6�   z�5�      V� 5�      .~�5�      �� �� 5�      $* -0.13Q�6,   �� 5�      T� 5�      $+ -0.264Q�61   5�      ._�5�      �� $, PART_EditableTextBox��6   #��z��6<   8�� #��z��6
  - �	#FF69AB84
����������	#FF333333$	��NaN��6�  $��0,0,19,0q�6�  . 6�   �� *
IsReadOnly+ �� *TemplatedParent+6�  5�      5�       5�      P� 5�       � {� .  . �5�      �� $ border��60    �@J�Opacity$
 0.56Q�6D   5�      P� 5�       �@J�IsKeyboardFocusWithin . . �5�      ��  � ��
 �   �63   5�      P� 5�      $/ 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $ shadow��6/    � ��$ 0,0,5,5q�6C   �� 5�      $ shadow��6.    �@ Color$ 	#71000000��6B   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6/    � ��$ 95��6K   5�      ]� 5�      0 5�      �� 5�      1 �@��
IsGrouping . 6:   �� 5�      "1 �@%�IsVirtualizingWhenGrouping .  6\   ./�5�      ��  � �� .  6F   5�      P� 5�      $/ DropDownScrollViewer��6C    � �� .  . �5�      �� $ 
opaqueRect��63    6K   �� *VerticalOffset+$  DropDownScrollViewer�� �@��Top�� 5�      $ 
opaqueRect��64    6L   �� *HorizontalOffset+$  DropDownScrollViewer�� �@��Left5�      5�      �� 5�   
   " ��63   .R�5�      � $ templateRoot��6    . ���	#FF333333 �	#FF2222222 .   5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   5�       5�      P� 5�       �@��HasItems .  6.   ]� 5�      0 5�      �� 5�      1 �@��
IsGrouping . 6:   �� 5�      "1 �@%�IsVirtualizingWhenGrouping .  6\   ./�5�      ��  � �� .  6F   5�      5�      �� 5�   
   " ��6,   .�5�      ��  �@�FocusVisualStyle8   61   �� 5�       � �� �	#FF2222226+   �� 5�       � �� �	#FF1A1A1A6,   �� 5�       � �� �	#FFABABAB6+   �� 5�       � ��$ 1q�60   �� 5       � ��$
 Auto=�6K   �� 5      � ��$
 Auto=�6I   �� 5      � ��$ 6,3,5,3q�6(   �� 5      � �� . 6>   �� 5      �@��PanningMode$
 Both=�69   �� 5      �@��IsFlicksEnabled .  67   �� 5      � ��8  6)   3 5     P� 5      �@��
IsEditable . . �5	     ��  � �� .  62   �� 5
      � ��$ 2q�60   �� 5      � ��8  61   5     5     5     5     