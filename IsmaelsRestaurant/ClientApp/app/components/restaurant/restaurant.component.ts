import { NavMenuComponent } from './../navmenu/navmenu.component';
import { Component, OnInit } from '@angular/core';
import { RestaurantService } from '../../Services/restaurant.service';
import { RestaurantModel } from './restaurant.model';

@Component({
    selector: 'restaurants',
    templateUrl: './restaurant.component.html',
    styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {
    
    private restaurants: any;
    private model: RestaurantModel;
    private nameUpdate: string;
    private searchName: string;

    //Controllers page
    private showRestaurants: boolean;
    private registerRestaurant: boolean;
    private editRestaurant: boolean; 

    constructor(private restaurantService: RestaurantService) {
        this.model = new RestaurantModel();
     }
    
    ngOnInit(): void {
        this.loadRestaurants();
        this.showRestaurants = true;
        this.registerRestaurant = false;
        this.editRestaurant = false;
    }

    loadRestaurants(){
        console.log("Carregando restaurantes...")
        this.restaurantService.getRestaurants().subscribe(restaurants => {
          this.restaurants = restaurants;
          console.log("Restaurantes carregados com sucesso...");
        }, error => console.log("ERROR:: " + error));
    }

    btnCancelRegister(){
        this.activePage();
        this.showRestaurants = true;
        console.log("Cancelou registro do item");
    }

    btnCancelEdit(){
        this.activePage();
        this.showRestaurants = true; 
        this.cleanForm();
        console.log("Cancelou edição do item");
    }

    btnCancelUpdate(){
        this.activePage();
        this.showRestaurants = true;
        console.log("Cancelou atualização do item");
    }

    btnNew(){
        this.activePage();
        this.registerRestaurant = true;
        console.log("Novo item");
    }
    
    btnRemove(event: number){
        this.model.id = event;
        console.log(this.model);
        this.restaurantService.deleteRestaurant(this.model)
                .subscribe(res => console.log(res), 
                error => this.loadRestaurants());    
        console.log("Excluiu item");
    }

    //#region CRUD

    btnSearch(){
        let result;
        console.log("Search:: " + this.searchName);
        this.restaurantService.searchRestaurants(this.searchName)
            .subscribe(res => this.showSearch(res), 
            error => console.log(error))        
        console.log("Pesquisando...");
    }

    showSearch(result: any){
        console.log(result)
        
        if(result != null || result != undefined){
            this.restaurants = result;
        }else{
            this.loadRestaurants();
        }
    }
    
    btnSave(){
        console.log(this.model);
        this.restaurantService.saveRestaurant(this.model)
            .subscribe(res => this.loadRestaurants());
        this.activePage();
        this.showRestaurants = true;
        console.log("Salvou item");
    }

    btnUpdate(){
        this.model.name = this.nameUpdate;
        this.restaurantService.updateRestaurant(this.model)
        .subscribe(res => this.loadRestaurants());
        this.activePage();
        this.showRestaurants = true;
        console.log(this.model);
        console.log("Atualizou item");
    }

    //#endregion

    btnEdit(restaurant: any){
        this.nameUpdate = restaurant.name;
        this.model.id = restaurant.id;
        this.activePage();
        this.editRestaurant = true;
        console.log("Editando item");
    }

    cleanForm(){
        this.model.name = "";
    }

    activePage(){
        this.editRestaurant = false;
        this.showRestaurants = false;
        this.registerRestaurant = false;
        this.cleanForm();
    }
}