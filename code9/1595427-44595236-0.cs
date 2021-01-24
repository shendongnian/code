    @{ // start a c# block
        string oc; // create a string variable
        if wURL == null { //before I used a "ternary" conditional, but this compiles to the same thing
            oc = ""; // if wURL is null set oc to empty string, so nothing will be written in the tag 
        } 
        else 
        { 
            oc = "onclick=window.open('" + @wURL + "','_blank')"; // set the onclick to open a window with the wURL variable
        }
    }
    <td class = "" @oc> 
    <!-- If the oc variable is empty, nothing will be written here, otherwise you'll get the onclick statement -->
