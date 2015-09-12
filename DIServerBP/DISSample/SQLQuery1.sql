SELECT T0.U_Vigencia AS 'Vigencia' , t0.U_LEntrega AS 'Lugar de entrega', T0.U_ClaveProv AS 'Clave Proveedor',
T00.Street AS 'DirecSuc',T00.StreetNo AS 'NumSuc',T00.Block AS 'ColSuc',T00.County AS 'CiudadSuc', T00.ZipCode AS 'CodSuc',T3.PicturName AS 'dibujo', 
T0.U_MetodoDePago AS 'Metodo Pago',
 T0.U_MontoLetra AS 'Monto Letra', T0.U_NumCtaPago AS ' CuentaPago',
            T0.U_XAM_LOGO AS 'Logo', T1.Visorder,T0.DocNum AS 'Cotización No:', T0.NumAtCard AS 'Depto' ,T0.Docdate AS 'Fecha',
            T0.CardCode  as 'Codigo del Cliente', T0.CardName AS 'Cliente', T0.Comments AS 'Comentario',
            T1.SubCatNum AS 'Codigo alternativo',T1.LineNum as 'Numero de partida',T1.SlpCode,T1.U_XAM_TE AS 'Tiempo de Entrega',
            T10.NAME AS 'Nom. Tiempo Entrega',T4.SlpName AS 'Vendedor', T0.Address AS 'Dirección',T0.Address2 AS 'Dirección2', 
            T0.GroupNum AS 'Condiciones de pago',T8.PymntGroup AS 'Condiciones de pago', t0.cntctcode AS 'Codigo Contacto',
            T5.Name AS 'Contacto',T6.INTERNAL_K, T7.E_Mail, T1.ItemCode AS 'Modelo', T1.Dscription AS 'Descripción',
            T1.Quantity AS 'Cantidad', T1.Price AS 'Precio Unitario',T0.DiscPrcnt AS 'PorcentajeN',t0.DiscSum AS '%DescuentoC', T0.DiscSumFC  AS 'Total descuento',
            T0.DiscSum AS 'Iva en pesos', T0.discsumfc AS 'Iva en Dolares',
CASE WHEN T0.doccur ='MXP'  /* es la moneda*/
     THEN T1.linetotal 
          ELSE T1.TotalFrgn
END  AS 'Total por Partida', T1.Currency AS 'moneda',T0.SysRate AS 'Tipo de cambio', 
CASE WHEN T0.DocCur='MXP' 
     THEN T0.VatSum 
          ELSE T0.VatSumFC 
END AS 'Iva 16%', 
CASE WHEN T0.doccur = 'MXP'
     THEN T0.DocTotal 
          ELSE t0.doctotalfc 
END AS 'Total Pesos', ((T0.DocTotal-DiscSumFC)/T9.Rate) AS 'Total USD' ,  T0.U_XAM_LOGO , T3.PicturName AS 'Imagen',
CASE WHEN T0.DocCur='MXP' 
     THEN T0.DocTotal
          ELSE T0.DocTotalFC
END AS 'Subtotal'

FROM  OQUT T0 LEFT JOIN QUT1 T1 ON T0.[DocEntry]=T1.[DocEntry]
            LEFT JOIN OWHS T00 ON T1.WhsCode=T00.WhsCode
			LEFT JOIN OITM T3 ON T1.[ItemCode]=T3.[ItemCode]  
			LEFT JOIN OSLP T4 ON T1.[SlpCode]=T4.[SlpCode]
			LEFT JOIN OCPR T5 ON T0.CntctCode=T5.CntctCode 
			LEFT JOIN OUSR T6 ON T0.usersign =T6.internal_k 
			LEFT JOIN  OUSR T7 ON T6.INTERNAL_K=T7.INTERNAL_K 
			LEFT JOIN OCTG T8 ON T0.GroupNum=T8.GroupNum 
			LEFT JOIN ORTT T9 ON T0.DocDate=T9.RateDate AND T9.Currency='USD' 
			
			LEFT JOIN dbo.[@TIEMPO_DE_ENTREGA] T10 ON T1.U_XAM_TE=T10.CODE 
where t0.docentry=1174