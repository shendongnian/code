    <?php
     
    	$arr = array(
    	    'GetProductSellableRequest' => 
    	        array(
    	            'wsVersion' => ????,
    	            'id' => ?????,
    	            'password' => ?????,
    				'productId' => ????,
    				'partId' => ????,
    				'isSellable' => ????        
    	);
    	 
    
    	    try {
    	        $sc = new SoapClient("ProductDataService.wsdl", array(
    	            'location' => 'http://api.proactiveclothing.com/services/Product.svc')
    	         );
    
    	        $resp = $sc-> Submit($arr); 
    	    
    	        echo(var_dump($resp));
    	    }
    	    catch (SoapFault $fault) {
    	        echo(var_dump($fault));
    	    }
    ?>
