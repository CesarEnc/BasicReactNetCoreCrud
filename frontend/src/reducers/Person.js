import {ActionTypes} from '../actions/Person'

const initialState ={
    list : []
}

export const Person = (state =initialState ,action) =>{
    
    switch(ActionTypes.type){
        case ActionTypes.GetAll:
            return{
                list:[...action.payload]
            }
            default:
                return state;
        }
}