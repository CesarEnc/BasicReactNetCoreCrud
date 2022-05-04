import api from './api'

export const ActionTypes = {
    Create : 'Create',
    Delete : 'Delete',
    GetAll : 'GetAll'
}

export const GetAll = () =>{
    api.Person().getAll().then(
        response => {
            dispatch({
                type: ActionTypes.GetAll,
                payload: response.data
            })
        }
    ).catch(err => console.log(err))
    
}