# Avalonia Color Picker
An Avalonia Color Picker. Includes a HSV color wheel, CIE views and Sketch like pickers. 



<p align="center">
  <a href="https://mikecodes.net">
    <img src="assets/hsv_wheel.png" alt="HSV Color Wheel" style="vertical-align:top; margin:4px">
  </a>  
</p>


## Getting Started 

### Import the XAML namespaces 
```

xmlns:cp="clr-namespace:ColorPicker;assembly=ColorPicker"	

```

### HSV Color Wheel 
```
<cp:ColorWheel ThumbSize="24" 
               SelectedColor="{Binding SelectedColor}" />
```

## Provided Converters
* RGBColor To Hex
* RGBColor To SolidBrush 