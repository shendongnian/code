    @model int
           
    @{
    switch (@Model)
    {
        case 1:
            <span>1st</span>
            break;
        case 2:
            <span>2nd</span>
            break;
        case 3:
            <span>3rd</span>
            break;
        case 4:
            <span>4th</span>
            break;
        case 5:
            <span>5th</span>
            break;
        default:
            <span>???</span>
            break;
    }
    }
