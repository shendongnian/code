    void pushArray(){
        EidolonClass store = AllUnitArray [0];
        Array.Copy (AllUnitArray, 1, AllUnitArray, 0, AllUnitArray.Length - 1);
        AllUnitArray[AllUnitArray.Length - 1] = store;
        for(int i=0;i<=AllUnitArray.Length;i++) {
            Debug.Log (AllUnitArray[i].name.ToString ());
        }
    }
