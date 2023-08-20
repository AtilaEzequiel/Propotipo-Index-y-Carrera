namespace Propotipo_Index_y_Carrera.wwwroot.Codigo
{
    public class Class
    {

        <div class="container">
  <br>
  <div id = "myCarousel" class="carousel slide row" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
      <li data-target="#myCarousel" data-slide-to="3"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner" role="listbox">

      <div class="item active ">
        <img src = "~/uploads/logo02.png" alt="Chania" width="460" height="345">
        <div class="carousel-caption">
          <h3>Chania</h3>
          <p>The atmosphere in Chania has a touch of Florence and Venice.</p>
        </div>
      </div>
     @foreach (var item in Model)
        {
            //   @if (item.Carreraslist.nombre!="atila" && item.Carreraslist.nombre!="dasd" && item.Carreraslist.nombre!="programa" )

            @if(item.categoria == "Carrera")
                {
                     < div class="item">
                        <img src = "~/uploads/1343.png" width="100%"  href="#victorModal" role="button" class="btn btn-large btn-primary " data-toggle="modal">
                        <div class="carousel-caption">
                          <h3>@Html.DisplayFor(modelItem => item.nombre)</h3>
                          <p>
                                  @*  <a asp-controller="MovieADO" asp-action="Index" class="modal-content" ><input type = "submit" value="Horarios" class="btn btn-primary  " /> </a>
                                        *@
                                        
                                        
                                                <a asp-action="Detalle" asp-route-id="@item.nombre"><input type = "submit" value="Details" class="btn btn-primary  " /></a> 
                                                <a asp-action="Delete" asp-route-id="@item.nombre"><input type = "submit" value="Delete" class="btn btn-primary  " /></a>
                              </p>
                        </div>
                      </div>
                  
                     
                                          
                                
                                                
                    
                                        
                                    
                      
                    
                } 
                @*
                     <div class="table-bordered">
                       
                      <h6>@Html.DisplayFor(modelItem => item.nombre)</h6>
                      <p>
                         @Html.DisplayFor(modelItem => item.Descripcion)
                          
                                   
                                        
                      </p>
            
                    </div>
                    *@
            }





    </ div >

    < !--Left and right controls -->
    <a class= "left carousel-control" href = "#myCarousel" role = "button" data - slide = "prev" >
      < span class= "glyphicon glyphicon-chevron-left" aria - hidden = "true" ></ span >
      < span class= "sr-only" > Previous </ span >
    </ a >
    < a class= "right carousel-control" href = "#myCarousel" role = "button" data - slide = "next" >
      < span class= "glyphicon glyphicon-chevron-right" aria - hidden = "true" ></ span >
      < span class= "sr-only" > Next </ span >
    </ a >
  </ div >
</ div >

    }
}




           < div class= "container-fluid bg-primary" >
                < div class= "carousel-inner" >


                        < div class= "carousel-item active" >
            @foreach(var item in Model) {
    //   @if (item.Carreraslist.nombre!="atila" && item.Carreraslist.nombre!="dasd" && item.Carreraslist.nombre!="programa" )

    @if(item.categoria == "Carrera")
                {



                            < img src = "~/uploads/logo02.png" width = "100%"  href = "#victorModal" role = "button" class= "btn btn-large btn-primary " data - toggle = "modal" >
                              < h3 > @Html.DisplayFor(modelItem => item.nombre) </ h3 >
                              < p >
                                  @*  < a asp - controller = "MovieADO" asp - action = "Index" class= "modal-content" >< input type = "submit" value = "Horarios" class= "btn btn-primary  " /> </ a >
                                        *@



                                                < a asp - action = "Detalle" asp - route - id = "@item.nombre" >< input type = "submit" value = "Details" class= "btn btn-primary  " /></ a >
                                                < a asp - action = "Delete" asp - route - id = "@item.nombre" >< input type = "submit" value = "Delete" class= "btn btn-primary  " /></ a >
                              </ p >
                     
                                          
                                
                                                
                    
                                        
                                    
                      
                    
                } 
                @*
                     < div class= "table-bordered" >


                      < h6 > @Html.DisplayFor(modelItem => item.nombre) </ h6 >
                      < p >
                         @Html.DisplayFor(modelItem => item.Descripcion)



                      </ p >


                    </ div >
                    *@
            }


                            </ div >

                       </ div >



            </ div >
